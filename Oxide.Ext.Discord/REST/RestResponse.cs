﻿using Newtonsoft.Json;

namespace Oxide.Ext.Discord.REST
{
    /// <summary>
    /// Represents a REST response from discord
    /// </summary>
    public class RestResponse
    {
        /// <summary>
        /// Data discord sent us
        /// </summary>
        public string Data { get; }

        /// <summary>
        /// Create new REST response with the given data
        /// </summary>
        /// <param name="data"></param>
        public RestResponse(string data)
        {
            Data = data;
        }

        /// <summary>
        /// Parse the data to it's given object
        /// </summary>
        /// <typeparam name="T">Type to be parsed as</typeparam>
        /// <returns>Data string parsed to JSON</returns>
        public T ParseData<T>() => JsonConvert.DeserializeObject<T>(Data);
    }
}
