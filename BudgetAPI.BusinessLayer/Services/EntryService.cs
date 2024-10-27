using BudgetAPI.BusinessLayer.Dtos;
using BudgetAPI.BusinessLayer.Factories;
using BudgetAPI.BusinessLayer.Responses;
using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Services
{
    public partial class Service : IService
    {
        public BaseResponse<EntryDto> CreateEntry(EntryDto entry)
        {
            if(entry.Amount <= 0)
            {
                return new BaseResponse<EntryDto>().Error(entry, $"Amount must be > 0", 400);
            }
            if(entry.AddedBy == null)
            {
                entry.AddedBy = GetId();
            }
            _dbContext.Entrys.Add(entry.ToEntity());
            _dbContext.SaveChanges();

            return new BaseResponse<EntryDto>().Success(entry, $"Successfully added new entry for amount {entry.Amount}.", 200);
        }
        public BaseResponse<EntryDto> UpdateEntry(EntryDto entry)
        {
            var existing = _dbContext.Entrys.FirstOrDefault(x => x.Id == entry.Id);
            string description = entry.Description?.Length > 40 ? entry.Description.Substring(0, 40) + "..." : entry.Description ?? "";
            if (existing == null)
            {
                return new BaseResponse<EntryDto>().Error(entry, $"The entry with amount {entry.Amount} and description '{description}' does not exist.", 404);
            }
            entry.UpdatedBy = GetId();
            existing = entry.ToEntity();
            _dbContext.SaveChanges();
            return new BaseResponse<EntryDto>().Success(entry, $"Successfully added entry with amount {entry.Amount} and description'{description}'.", 200);
        }
        public BaseResponse<EntryDto> DeleteEntry(EntryDto entry)
        {
            var existing = _dbContext.Entrys.FirstOrDefault(x => x.Id == entry.Id);
            string description = entry.Description?.Length > 40 ? entry.Description.Substring(0, 40) + "..." : entry.Description ?? "";
            if (existing == null)
            {
                return new BaseResponse<EntryDto>().Error(entry, $"The entry with amount {entry.Amount} and description '{description}' does not exist.", 404);
            }
            //not actually delete, just flag as deleted
            entry.IsDeleted = true;
            entry.UpdatedBy = GetId();
            existing = entry.ToEntity();
            _dbContext.SaveChanges();
            return new BaseResponse<EntryDto>().Success(entry, $"You will no longer see the entry, however, it still exists in the database", 200);
        }
        public BaseResponse<List<EntryDto>> GetEntriesDateRange(int userId, DateTime fromDate, DateTime toDate, int? categoryId)
        {
            var entries = _dbContext.Entrys.Where(x => x.AddedBy == userId && x.Date > fromDate && x.Date < toDate);
            if(categoryId != null)
            {
                entries.Where(x => x.CategoryId == categoryId);
            }
            if(!entries.Any())
            {
                return new BaseResponse<List<EntryDto>>().Error(null, $"No entries were found, either add entries or try changing the category filter.", 404);
            }
            return new BaseResponse<List<EntryDto>>().Success(entries.ToList().ConvertAll(x => x.ToDomain()), "success", 200);
        }
        public BaseResponse<List<EntryDto>> GetEntries(int userId, int? categoryId)
        {
            var entries = _dbContext.Entrys.Where(x => x.AddedBy == userId);
            if (categoryId != null)
            {
                entries.Where(x => x.CategoryId == categoryId);
            }
            if (!entries.Any())
            {
                return new BaseResponse<List<EntryDto>>().Error(null, $"No entries were found, either add entries or try changing the category filter.", 404);
            }
            return new BaseResponse<List<EntryDto>>().Success(entries.ToList().ConvertAll(x => x.ToDomain()), "success", 200);
        }
        public BaseResponse<EntryDto> GetEntry(int id)
        {
            var entry = _dbContext.Entrys.FirstOrDefault(x => x.Id == id);
            if (entry == null)
            {
                return new BaseResponse<EntryDto>().Error(null, $"No entries were found with id {id}.", 404);
            }
            return new BaseResponse<EntryDto>().Success(entry.ToDomain(), "success", 200);
        }
    }
}
