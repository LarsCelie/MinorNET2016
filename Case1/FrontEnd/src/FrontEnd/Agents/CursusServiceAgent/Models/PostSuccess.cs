// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace FrontEnd.Agents.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class PostSuccess
    {
        /// <summary>
        /// Initializes a new instance of the PostSuccess class.
        /// </summary>
        public PostSuccess() { }

        /// <summary>
        /// Initializes a new instance of the PostSuccess class.
        /// </summary>
        public PostSuccess(int? inserted = default(int?), int? total = default(int?))
        {
            Inserted = inserted;
            Total = total;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "inserted")]
        public int? Inserted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

    }
}