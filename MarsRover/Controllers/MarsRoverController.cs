using RoverLibrary;
using Swashbuckle.Swagger.Annotations;
using System.Net;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace MarsRover.Controllers
{
    [Route("api/marsrover/{action}")]
    public class MarsRoverController : ApiController
    {
        IMarsRoverService roverService = new MarsRoverService();
        [HttpPost]
        [Route("api/rover/create")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Success Response")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid Payload")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal Server Error")]
        public IHttpActionResult Create([FromBody]RoverRequest roverRequest)
        {
            if (roverRequest.RoverId <= 0 || string.IsNullOrEmpty(roverRequest.RoverName))
                return Content(HttpStatusCode.BadRequest, "Invalid data.");

            var rover = roverService.Find(roverRequest.RoverId);

            if (rover != null)
                return Content(HttpStatusCode.BadRequest, "Rover already available.");

            roverService.Add(new RoverLibrary.MarsRover(roverRequest.RoverId, roverRequest.RoverName));

            return Ok("Rover Created.");
        }
        [HttpPost]
        [Route("api/rover/update")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Success Response")]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid Input Data")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "No Matching Rover Found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal Server Error")]
        public IHttpActionResult Update([FromBody]RoverRequest roverRequest)
        {
            if (roverRequest.RoverId <= 0 || string.IsNullOrEmpty(roverRequest.RoverName))
                return Content(HttpStatusCode.BadRequest, "Invalid data.");

            var rover = roverService.Find(roverRequest.RoverId);

            if (rover == null)
                return Content(HttpStatusCode.NoContent, "No Matching Rover Found");

            roverService.Update(roverRequest.RoverId, roverRequest.RoverName);

            return Ok("Rover Updated");
        }
        [HttpGet]
        [Route("api/rover/move/{roverId}/{command}")]
        [SwaggerResponse(HttpStatusCode.OK, Description = "Success Response", Type = typeof(RoverLibrary.MarsRover))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid Input Data")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "No Matching Rover Found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal Server Error")]
        public IHttpActionResult Move([FromUri]int roverId, [FromUri]string command)
        {
            if (roverId <= 0 || string.IsNullOrEmpty(command))
                return Content(HttpStatusCode.BadRequest, "Invalid data.");

            var marsRover = roverService.Find(roverId);

            if (marsRover == null)
                return Content(HttpStatusCode.NoContent, "No Matching Rover Found");

            if (!Regex.IsMatch(command, @"^[LRM]+$"))
                return BadRequest("Invalid Command");

            foreach (var instruction in command)
            {
                switch (instruction)
                {
                    case 'L':
                        roverService.TurnLeft(marsRover);
                        break;
                    case 'R':
                        roverService.TurnRight(marsRover);
                        break;
                    case 'M':
                        roverService.Move(marsRover);
                        break;
                    default:
                        break;
                }
            }
            return Json(marsRover);
        }

        [SwaggerResponse(HttpStatusCode.OK, Description = "Success Response", Type = typeof(RoverLibrary.MarsRover))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Invalid Payload")]
        [SwaggerResponse(HttpStatusCode.NoContent, Description = "No Matching Rover Found")]
        [SwaggerResponse(HttpStatusCode.InternalServerError, Description = "Internal Server Error")]
        [Route("api/rover/{roverId}")]
        public IHttpActionResult GetRover([FromUri]int roverId)
        {
            if (roverId <= 0)
                return Content(HttpStatusCode.BadRequest, "Invalid rover Id.");

            var marsRover = roverService.Find(roverId);

            if (marsRover == null)
                return Content(HttpStatusCode.NoContent, "No Matching Rover Found");

            return Json(marsRover);
        }

    }
}
