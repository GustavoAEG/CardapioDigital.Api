using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CardapioDigital.Api.Controllers.Admin
{
    [ApiController]
    [Route("admin/restaurants/{rid:guid}/tables")]
    [Authorize]
    public class TablesController:ControllerBase
    {
    }
}
