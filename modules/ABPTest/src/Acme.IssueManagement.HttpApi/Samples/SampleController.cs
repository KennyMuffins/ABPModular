using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;

namespace Acme.IssueManagement.Samples
{
    [RemoteService]
    [Route("api/IssueManagement/sample")]
    public class SampleController : IssueManagementController, ISampleAppService
    {
        private readonly ISampleAppService _sampleAppService;

        public SampleController(ISampleAppService sampleAppService)
        {
            _sampleAppService = sampleAppService;
        }

        [HttpGet]
        public async Task<List<Items>> GetAsync()
        {

            return await _sampleAppService.GetAsync();
        }

        [HttpGet("{guid}")]
        public async Task<Items> GetAsyncById(string guid)
        {
            return await _sampleAppService.GetAsyncById(guid);
        }


        [HttpGet]
        [Route("authorized")]
        [Authorize]
        public async Task<Response> GetAuthorizedAsync()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<PostResponse> CreateAsync(ContentDto contentDto)
        {
            return await _sampleAppService.CreateAsync(contentDto);
        }

        [HttpPut("{guid}")]
        public async Task<PostResponse> UpdateAsync(string guid)
        {
            return await _sampleAppService.UpdateAsync(guid);
        }
    }
}
