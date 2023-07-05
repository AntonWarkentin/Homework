﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Home_16.Models
{
    public class TestCasesBulkModel
    {
        [JsonProperty("cases")]
        public TestCaseModel[] Cases { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestCasesBulkModel model &&
                   Cases.SequenceEqual(model.Cases);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Cases);
        }
    }
}
