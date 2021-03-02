using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models
{
    public abstract class CodesBaseModel
    {
        /// <summary>
        ///  International Air Transport Association Code 
        /// </summary>
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }
        /// <summary>
        /// International Civil Aviation Organization Code
        /// </summary>
        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }
    }
}
