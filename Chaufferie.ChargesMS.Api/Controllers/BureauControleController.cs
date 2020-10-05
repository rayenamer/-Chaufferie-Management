using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chaufferie.ChargesMS.Domain.Commands;
using Chaufferie.ChargesMS.Domain.Handlers;
using Chaufferie.ChargesMS.Domain.Interfaces;
using Chaufferie.ChargesMS.Domain.Models;
using Chaufferie.ChargesMS.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chaufferie.ChargesMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BureauControleController : ControllerBase
    {
        private readonly IGenericRepository<BureauControle> repository;

        #region Constructor
        public BureauControleController(IGenericRepository<BureauControle> repository)
        {
            this.repository = repository;

        }
        #endregion

        #region Read Function
        // GET: api/BureauControle
        [HttpGet("GetListBureauControle")]
        public async Task<IEnumerable<BureauControle>> GetListBureauControle() =>
             await (new GetListGenericHandler<BureauControle>(repository)).Handle(new GetListGenericQuery<BureauControle>(condition: null, includes: null), new CancellationToken());

        // GET: api/BureauControle/5
        [HttpGet("GetBureauControle")]
        public async Task<BureauControle> GetBureauControle(Guid id) =>
            await (new GetGenericHandler<BureauControle>(repository)).Handle(new GetGenericQuery<BureauControle>(condition: x => x.BureauControleId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/BureauControle
        [HttpPost("PostBureauControle")]
        public async Task<BureauControle> PostBureauControle([FromBody] BureauControle BureauControle) =>
            await (new AddGenericHandler<BureauControle>(repository)).Handle(new AddGenericCommand<BureauControle>(BureauControle), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/BureauControle/5
        [HttpPut("PutBureauControle")]
        public async Task<BureauControle> PutBureauControle([FromBody] BureauControle bureauControle) =>
           await (new PutGenericHandler<BureauControle>(repository)).Handle(new PutGenericCommand<BureauControle>(bureauControle), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/BureauControle/5
        [HttpDelete("DeleteBureauControle")]
        public async Task<BureauControle> DeleteBureauControle(Guid id) =>
           await (new RemoveGenericHandler<BureauControle>(repository)).Handle(new RemoveGenericCommand<BureauControle>(id), new CancellationToken());
        #endregion
    }
}