using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BudgetAPI.BusinessLayer.Helpers
{
    public static class UserHelper
    {
        public static int GetId()
        {
            var claimsUser = Thread.CurrentPrincipal?.Identity as ClaimsIdentity;
            if(claimsUser != null && int.TryParse(claimsUser.Actor.Claims.Where(x => x.Type == "userid").FirstOrDefault().Value, out int id))
            {
                return id;
            }
            else
            {
                return -1;
            }
        }
    }
}
