using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using simplebank.Exceptions;
using simplebank.Facades.interfaces;
using simplebank.Model;

namespace simplebank.Controllers
{
    [ApiController]
    [Route("api/v1/transfer")]
    public class TransferController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ITransferFacade _transferFacade;

        public TransferController(
            ILogger<UserController> logger,
            ITransferFacade transferFacade
        )
        {
            _logger = logger;
            _transferFacade = transferFacade;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransferAsync(
            [FromBody] TransferCreateDTO transfer
        ) {
            try
            {
                return Ok(
                    await _transferFacade.CreateAsync(transfer: transfer)
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<TransferResponseDTO>>> ListTransfersAsync()
        {
            try
            {
                return Ok(
                    await _transferFacade.ListAsync()
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DetailsTransferAsync(
            int id
        ) {
            try
            {
                return Ok(
                    await _transferFacade.DetailsAsync(id: id)
                );
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}