using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Roni.Pomodoro.Services;

namespace Roni.Pomodoro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeBlocksController : ControllerBase
    {
        private readonly ITimeBlockService _timeBlockService;
        private readonly ILogger _logger;

        public TimeBlocksController(ILogger logger, ITimeBlockService service)
        {
            _logger = logger;
            _timeBlockService = service;
        }

        /// <summary>
        /// Returns the timeblocks in the provided date range for the corresponding user.
        /// </summary>
        /// <param name="beginDate">Date corresponding to the start of the timeblock.</param>
        /// <param name="endDate">Date corresponding to the end of the timeblock.</param>
        /// <param name="userId">Corresponding User.</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetTimeBlocks(DateTime beginDate, DateTime endDate, Guid userId)
        {
            try
            {
                return Ok(_timeBlockService.GetTimeBlocks(beginDate, endDate, userId));
            }
            catch (SqlException exception)
            {
                _logger.Log(LogLevel.Error, exception,"Database returned error.");
                return StatusCode(500);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An unknown error has occurred.");
                return StatusCode(500);
            }
        }
    }
}