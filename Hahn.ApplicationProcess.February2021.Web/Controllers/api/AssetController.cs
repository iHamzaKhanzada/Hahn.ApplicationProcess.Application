using Hahn.ApplicationProcess.February2021.Domain;
using Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.CreateAsset;
using Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetDetail;
using Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Hahn.ApplicationProcess.February2021.Web.Controllers.api
{

    [ApiController]
    [Route("api/[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssetController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<AssetListVM>> Get()
        {
            var vm = await _mediator.Send(new GetAssetListQuery());
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDetailVM>> Get(int id)
        {
            var vm = await _mediator.Send(new GetAssetDetailQuery { Id = id });
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAssetCommand command)
        {
            var assetId = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id = assetId }, assetId);
        }



        // PUT api/<AssetController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AssetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
