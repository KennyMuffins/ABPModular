using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.IssueManagement.Samples
{
    public interface ISampleAppService : IApplicationService
    {
        //public Task<List<SampleDto>> GetAllAsync();

        Task<List<Items>> GetAsync();

        Task<Items> GetAsyncById(string guid);

        Task<Response> GetAuthorizedAsync();

        Task<PostResponse> CreateAsync(ContentDto contentDto);

        Task<PostResponse> UpdateAsync(string guid);

    }
}
