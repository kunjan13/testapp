using System;
using System.Collections.Generic;
namespace AuditAppPcl.Entities.Response
{
    public class GetServicePathResponse
    {
        public bool Sucsess { get; set; }
        public List<string> Exception { get; set; }
        public string ServicePath { get; set; }
    }
}
