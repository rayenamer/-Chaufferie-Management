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
    public class TypeConsommableController : ControllerBase
    {
        private readonly IGenericRepository<TypeConsommable> repository;

        #region Constructor
        public TypeConsommableController(IGenericRepository<TypeConsommable> repository)
        {
            this.repository = repository;

        }
        #endregion

        #region Read Function
        // GET: api/TypeConsommable
        [HttpGet("GetListTypeConsommable")]
        public async Task<IEnumerable<TypeConsommable>> GetListTypeConsommable() =>
             await (new GetListGenericHandler<TypeConsommable>(repository)).Handle(new GetListGenericQuery<TypeConsommable>(condition: null, includes: null), new CancellationToken());

        // GET: api/TypeConsommable/5
        [HttpGet("GetTypeConsommable")]
        public async Task<TypeConsommable> GetTypeConsommable(Guid id) =>
            await (new GetGenericHandler<TypeConsommable>(repository)).Handle(new GetGenericQuery<TypeConsommable>(condition: x => x.TypeConsommableId.Equals(id), null), new CancellationToken());
        #endregion

        #region Add Function
        // POST: api/TypeConsommable
        [HttpPost("PostTypeConsommable")]
        public async Task<TypeConsommable> PostTypeConsommable([FromBody] TypeConsommable TypeConsommable) =>
            await (new AddGenericHandler<TypeConsommable>(repository)).Handle(new AddGenericCommand<TypeConsommable>(TypeConsommable), new CancellationToken());
        #endregion

        #region Update Funtion
        // PUT: api/TypeConsommable/5
        [HttpPut("PutTypeConsommable")]
        public async Task<TypeConsommable> PutTypeConsommable([FromBody] TypeConsommable TypeConsommable) =>
           await (new PutGenericHandler<TypeConsommable>(repository)).Handle(new PutGenericCommand<TypeConsommable>(TypeConsommable), new CancellationToken());
        #endregion

        #region Remove Function
        // DELETE: api/TypeConsommable/5
        [HttpDelete("DeleteTypeConsommable")]
        public async Task<TypeConsommable> DeleteTypeConsommable(Guid id) =>
           await (new RemoveGenericHandler<TypeConsommable>(repository)).Handle(new RemoveGenericCommand<TypeConsommable>(id), new CancellationToken());
        #endregion
    }
}