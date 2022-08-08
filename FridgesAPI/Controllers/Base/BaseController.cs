using FridgesData.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers.Base
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        // returns the current authenticated account (null if not logged in)
        public AccountEntity Account => (AccountEntity)HttpContext.Items["Account"];
    }
}
