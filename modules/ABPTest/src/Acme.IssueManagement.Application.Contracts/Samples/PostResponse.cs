using System;
using System.Collections.Generic;

namespace Acme.IssueManagement.Samples
{
    public class PostResponse
    {
        public string id { get; set; }
        public string createdBy { get; set; }
        public string lastModifiedBy { get; set; }
        public ContentDto data { get; set; }
    }
}