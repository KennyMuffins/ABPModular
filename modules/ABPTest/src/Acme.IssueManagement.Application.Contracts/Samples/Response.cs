using System;
using System.Collections.Generic;

namespace Acme.IssueManagement.Samples
{
    public class Response
    {
        public int total { get; set; }
        public List<Items> items { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

    }

    public class Items
    {
        public string id { get; set; }
        public string createdBy { get; set; }
        public string lastModifiedBy { get; set; }
        public string Status { get; set; }
        public string StatusColor { get; set; }
        public string SchemaName { get; set; }
        public ContentDto data { get; set; }

    }
}