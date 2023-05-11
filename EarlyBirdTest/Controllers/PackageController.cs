using Microsoft.AspNetCore.Mvc;
using EarlyBirdTest.DAL.Models;
using EarlyBirdTest.Exceptions;
using EarlyBirdTest.Services;

namespace EarlyBirdTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageController : ControllerBase
    {
        private KolliService _kolliService;

        public PackageController(KolliService kolliService)
        {
            _kolliService = kolliService ?? throw new ArgumentNullException(nameof(kolliService)); ;
        }

        [HttpGet]
        public ActionResult<List<Kolli>> Get()
        {
            var kollis = _kolliService.GetAllKollis();
            return Ok(kollis);
        }

        [HttpGet("{kolliid}")]
        public ActionResult<Kolli> Get(string kolliid)
        {
            try
            {
                return Ok(_kolliService.GetKolliById(kolliid));
            }
            catch (KolliNotFoundException knfEx)
            {
                return BadRequest(knfEx.Message);
            }
            catch (MalformedKolliIdException mkiEx)
            {
                return BadRequest(mkiEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Kolli kolli)
        {
            try
            {
                _kolliService.InsertKolli(kolli);
                return Ok();
            }
            catch (KolliInvalidException kiEx)
            {
                return BadRequest(kiEx.Message);
            }
            catch (KolliAlreadyExistsException kaeEx)
            {
                return BadRequest(kaeEx.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}