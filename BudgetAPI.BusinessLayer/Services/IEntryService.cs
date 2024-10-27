using BudgetAPI.BusinessLayer.Dtos;
using BudgetAPI.BusinessLayer.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Services
{
    public partial interface IService
    {
        BaseResponse<EntryDto> CreateEntry(EntryDto entry);
        BaseResponse<EntryDto> UpdateEntry(EntryDto entry);
        BaseResponse<EntryDto> DeleteEntry(EntryDto entry);
        BaseResponse<List<EntryDto>> GetEntriesDateRange(int userId, DateTime? fromDate, DateTime? toDate, int? categoryId);
        BaseResponse<List<EntryDto>> GetEntries(int userId, int? categoryId);
        BaseResponse<EntryDto> GetEntry(int id);
    }
}
