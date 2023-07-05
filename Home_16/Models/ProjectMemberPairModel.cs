using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_16.Models
{
    public class ProjectMemberPairModel
    {
        [JsonProperty("member_id")]
        public int MemberId { get; set; }

        [JsonProperty("code")]
        public string? ProjectCode { get; set; }
    }
}
