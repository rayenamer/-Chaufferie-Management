//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Chaufferie.ChargesMS.Domain.Commands;
//using Chaufferie.ChargesMS.Domain.Handlers;
//using Chaufferie.ChargesMS.Domain.Interfaces;
//using Chaufferie.ChargesMS.Domain.Models;
//using Chaufferie.ChargesMS.Domain.Queries;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Chaufferie.ChargesMS.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TypeInterventionController : ControllerBase
//    {
//        private readonly IGenericRepository<TypeIntervention> repository;

//        #region Constructor
//        public TypeInterventionController(IGenericRepository<TypeIntervention> repository)
//        {
//            this.repository = repository;

//        }
//        #endregion

//        #region Read Function
//        [HttpGet("GetListTypeIntervention")]
//        public async Task<IEnumerable<TypeIntervention>> GetListTypeIntervention() =>
//             await (new GetListGenericHandler<TypeIntervention>(repository)).Handle(new GetListGenericQuery<TypeIntervention>(condition: null, includes: null), new CancellationToken());


//        [HttpGet("GetTypeIntervention")]
//        public async Task<TypeIntervention> GetTypeIntervention(Guid id) =>
//            await (new GetGenericHandler<TypeIntervention>(repository)).Handle(new GetGenericQuery<TypeIntervention>(condition: x => x.TypeInterventionId.Equals(id), null), new CancellationToken());
//        #endregion

//        #region Add Function
//        [HttpPost("PostTypeIntervention")]
//        public async Task<TypeIntervention> PostTypeIntervention([FromBody] TypeIntervention typeIntervention) =>
//            await (new AddGenericHandler<TypeIntervention>(repository)).Handle(new AddGenericCommand<TypeIntervention>(typeIntervention), new CancellationToken());
//        #endregion

//        #region Update Funtion
//        [HttpPut("PutTypeIntervention")]
//        public async Task<TypeIntervention> PutTypeIntervention([FromBody] TypeIntervention typeIntervention) =>
//           await (new PutGenericHandler<TypeIntervention>(repository)).Handle(new PutGenericCommand<TypeIntervention>(typeIntervention), new CancellationToken());
//        #endregion

//        #region Remove Function
//        [HttpDelete("DeleteTypeIntervention")]
//        public async Task<TypeIntervention> DeleteTypeIntervention(Guid id) =>
//           await (new RemoveGenericHandler<TypeIntervention>(repository)).Handle(new RemoveGenericCommand<TypeIntervention>(id), new CancellationToken());
//        #endregion
//    }
//}