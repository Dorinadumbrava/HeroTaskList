using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using HeroTaskList.EntityFramework;
using HeroTaskList.GraphQL;
using HeroTaskList.Repository_Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeroTaskList.Controllers
{
    [Route("graphql")]
    public class GraphQlController : Controller
    {
        private readonly GraphQLQuery _graphQLQuery;
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQlController(GraphQLQuery graphQLQuery, IDocumentExecuter documentExecuter, ISchema schema)
        {
            _graphQLQuery = graphQLQuery;
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLParameter query)
        {
            var executionOptions = new ExecutionOptions { Schema = _schema, Query = query.Query, UserContext = User };
            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}