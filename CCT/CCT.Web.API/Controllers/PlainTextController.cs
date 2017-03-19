using CCT.Infrastructure.Commands;
using CCT.Infrastructure.Entity;
using CCT.Infrastructure.Queries;
using CCT.Web.API.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace CCT.Web.API.Controllers
{
    [RoutePrefix("api/plaintexts")]
    public class PlaintextController : ApiController
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public PlaintextController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpPost, Route("")]
        public int AddNewPlaintext(PlaintextModel plaintext)
        {
            return _commandDispatcher.Execute<AddNewPlaintextCommand, int>(new AddNewPlaintextCommand(plaintext.Content));
        }

        [HttpGet, Route("")]
        public IEnumerable<Plaintext> GetAllPlaintexts()
        {
            return _queryDispatcher.Execute(new GetAllPlaintexts());
        }

        [HttpGet, Route("{plaintextId:int}")]
        public Plaintext GetPlaintext(int plaintextId)
        {
            return _queryDispatcher.Execute(new GetPlaintextById(plaintextId));
        }
    }
}