using System;
using System.Threading.Tasks;
using Application.Batch.Commands.CreateBatch;
using Application.Batch.Queries.GetBatchDetail;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BatchController : BaseController
    {
        // POST api/batch
        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody]CreateBatchCommand command)
        {
            return await Mediator.Send(command);
        }

        // GET api/batch/batchId
        [HttpGet("{batchId}")]
        public async Task<BatchDetailModel> Details(Guid batchId)
        {
            return await Mediator.Send(new BatchDetailQuery{BatchId = batchId});
        }
    }
}