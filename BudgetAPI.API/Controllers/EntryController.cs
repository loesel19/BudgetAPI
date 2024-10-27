using BudgetAPI.BusinessLayer.Dtos;
using BudgetAPI.BusinessLayer.Responses;
using BudgetAPI.BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BudgetAPI.API.Controllers
{
    public class EntryController : BaseController
    {
        public EntryController(IService serviceProvider) : base(serviceProvider)
        {

        }

        //code partly used from https://stackoverflow.com/questions/77189996/upload-files-to-a-minimal-api-endpoint-in-net-8
        public IActionResult uploadFile(int? formType)
        {
            if (!Request.HasFormContentType || Request.Form.Files.Count == 0)
            {
                return Json(new BaseResponse<List<EntryDto>>().Error(null, "No file provided.", 400));
            }
                
            var file = Request.Form.Files.FirstOrDefault();
            if (file == null || file.Length == 0)
            {
                return Json(new BaseResponse<List<EntryDto>>().Error(null, "Provided file was empty.", 400));
            }
            //make service call for handling the file parse
            return Ok();                        
            
        }

    }
}
