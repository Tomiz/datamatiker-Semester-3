using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyRestService
{
    [DataContract]
    public class Products
    {
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string CategoryName { get; set; }
        [DataMember]
        public int Price { get; set; }
    }
}