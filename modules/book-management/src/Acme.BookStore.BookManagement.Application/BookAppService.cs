using System;
using Acme.BookStore.BookManagement.Authorization;
using Acme.BookStore.BookManagement.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.BookManagement
{
    public class BookAppService :
        CrudAppService<Book, BookDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateBookDto, CreateUpdateBookDto>,
        IBookAppService
    {
        public BookAppService(IRepository<Book, Guid> repository)
            : base(repository)
        {
            GetPolicyName = BookManagementPermissions.Books.Default;
            GetListPolicyName = BookManagementPermissions.Books.Default;
            CreatePolicyName = BookManagementPermissions.Books.Create;
            UpdatePolicyName = BookManagementPermissions.Books.Edit;
            DeletePolicyName = BookManagementPermissions.Books.Delete;
        }
    }
}