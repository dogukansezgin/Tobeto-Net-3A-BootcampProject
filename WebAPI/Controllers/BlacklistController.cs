using Business.Abstracts;
using Business.Requests.Blacklists;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlacklistController : BaseController
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpPost]
        public IActionResult Add(CreateBlacklistRequest request)
        {
            return HandleDataResult(_blacklistService.Add(request));
        }

        [HttpDelete]
        public IActionResult Delete(DeleteBlacklistRequest request)
        {
            return HandleDataResult(_blacklistService.Delete(request));
        }

        [HttpPut]
        public IActionResult Update(UpdateBlacklistRequest request)
        {
            return HandleDataResult(_blacklistService.Update(request));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return HandleDataResult(_blacklistService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return HandleDataResult(_blacklistService.GetById(id));
        }
    }
}
