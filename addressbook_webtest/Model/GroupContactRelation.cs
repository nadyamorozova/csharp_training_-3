using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_webtest
{
    [Table(Name = "address_in_groups")]
   public class GroupContactRelation
    {
        [Column(Name = "group_id")]
        public string Grogroup_id { get; set; }

        [Column(Name = "id")]
        public string ContactId { get; set; }
    }
}
