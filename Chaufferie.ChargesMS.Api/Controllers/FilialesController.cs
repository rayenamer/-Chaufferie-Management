using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Chaufferie.ChargeMS.Data.Context;
using Chaufferie.ChargesMS.Domain.Models;
using Chaufferie.ChargesMS.Domain.Interfaces;
using Chaufferie.ChargesMS.Domain.Queries;
using MediatR;
using Chaufferie.ChargesMS.Domain.Commands;
using System.Threading;
using Chaufferie.ChargesMS.Domain.Handlers;

namespace Chaufferie.ChargesMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilialesController : ControllerBase
    {
        private readonly IGenericRepository<Filiale> repository;

        public FilialesController(IGenericRepository<Filiale> repository)
        {
            this.repository = repository;
        }


        // PUT: api/Filiales/5
        [HttpPut("UpdateFiliale")]
        public async Task<Filiale> UpdateFiliale([FromBody] Filiale filiale) =>
           await (new PutGenericHandler<Filiale>(repository)).Handle(new PutGenericCommand<Filiale>(filiale), new CancellationToken());
         

        // POST: api/Filiales
        [HttpPost("AddFiliale")]
        public async Task<Filiale> AddFiliale([FromBody] Filiale filiale) =>
            await (new AddGenericHandler<Filiale>(repository)).Handle(new AddGenericCommand<Filiale>(filiale), new CancellationToken());

        // DELETE: api/Filiales
        [HttpDelete("DeleteFiliale")]
        public async Task<Filiale> DeleteFiliale(Guid filialeId) =>
            await (new RemoveGenericHandler<Filiale>(repository)).Handle(new RemoveGenericCommand<Filiale>(filialeId), new CancellationToken());
    }
}
