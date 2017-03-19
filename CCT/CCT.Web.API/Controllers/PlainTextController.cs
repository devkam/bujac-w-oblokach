using CCT.Domain;
using CCT.Domain.Commands;
using CCT.Infrastructure;
using CCT.Infrastructure.Commons;
using CCT.Infrastructure.DTO;
using CCT.Infrastructure.Queries;
using CCT.Web.API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CCT.Web.API.Controllers
{
    [RoutePrefix("api/plaintexts")]
    public class PlaintextController : ApiController
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryDispatcher _queryDispatcher;

        public PlaintextController(ICommandBus commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandBus = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost, Route("")]
        public void AddNewPlaintext(PlaintextModel plaintext)
        {
            _commandBus.Handle(new AddPlaintextCommand(plaintext.Content));
        }

        [HttpGet, Route("")]
        public IEnumerable<PlaintextDTO> GetAllPlaintexts()
        {
            return _queryDispatcher.Execute(new GetAllPlaintexts());
        }

        [HttpGet, Route("{plaintextId:int}")]
        public PlaintextDTO GetPlaintext(int plaintextId)
        {
            return _queryDispatcher.Execute(new GetPlaintextById(plaintextId)).MapTo<PlaintextDTO>();
        }
    }
}