using Hahn.ApplicationProcess.February2021.Domain;
using Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.CreateAsset;
using Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.DeleteAsset;
using Hahn.ApplicationProcess.February2021.Domain.Commands.Assets.UpdateAsset;
using Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetDetail;
using Hahn.ApplicationProcess.February2021.Domain.Queries.Assets.GetAssetList;
using MediatR;
using Microsoft.AspNetCore.Http;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateAssetCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteAssetCommand { Id = id });
            return NoContent();
        }
    }
}
