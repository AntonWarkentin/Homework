using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_16.Models
{
    public class MemberModel
    {
        [JsonProperty("member_id")]
        public int Id { get; set; }
    }
}
