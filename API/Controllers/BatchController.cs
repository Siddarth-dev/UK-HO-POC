using System;
using System.Threading.Tasks;
using Application.Batch.Commands.CreateBatch;
using Application.Batch.Queries.GetBatchDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BatchController : BaseController
    {
        // POST api/batch
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> Create([FromBody]CreateBatchCommand command)
        {
            return Ok(new { batchId = await Mediator.Send(command)});
        }

        // GET api/batch/batchId
        [HttpGet("{batchId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status410Gone)]
        public async Task<BatchDetailModel> Details(Guid batchId)
        {
            return await Mediator.Send(new BatchDetailQuery{BatchId = batchId});
            // return Ok(await Mediator.Send(new BatchDetailQuery{BatchId = batchId}));
        }
    }
}