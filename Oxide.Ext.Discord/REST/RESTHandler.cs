﻿using Oxide.Ext.Discord.Logging;

namespace Oxide.Ext.Discord.REST
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RESTHandler
    {
        private List<Bucket> buckets = new List<Bucket>();

        private string apiKey;

        private Dictionary<string, string> headers;

        private readonly LogLevel _logLevel;

        public RESTHandler(string apiKey, LogLevel logLevel)
        {
            this.apiKey = apiKey;
            _logLevel = logLevel;
            
            // Version
            string version = "";
            var exts = Oxide.Core.Interface.Oxide.GetAllExtensions();
            foreach (var ext in exts)
            {
                if (ext.Name != "Discord") continue;
                version = $"{ext.Version.Major}.{ext.Version.Minor}.{ext.Version.Patch}";
                break;
            }
            //-

            headers = new Dictionary<string, string>()
            {
                { "Authorization", $"Bot {this.apiKey}" },
                { "Content-Type", "application/json" },
                { "User-Agent", $"DiscordBot (https://github.com/Trickyyy/Oxide.Ext.Discord, {version})" }
            };
        }

        public void Shutdown()
        {
            buckets.ForEach(x =>
            {
                x.Disposed = true;
                x.Close();
            });
        }

        public void DoRequest(string url, RequestMethod method, object data, Action callback)
        {
            CreateRequest(method, url, headers, data, response => callback?.Invoke());
        }

        public void DoRequest<T>(string url, RequestMethod method, object data, Action<T> callback)
        {
            CreateRequest(method, url, headers, data, response =>
            {
                callback?.Invoke(response.ParseData<T>());
            });
        }

        private void CreateRequest(RequestMethod method, string url, Dictionary<string, string> headers, object data, Action<RestResponse> callback)
        {
            // this is bad I know, but I'm way too fucking lazy to go 
            // and rewrite every single fucking REST request call
            string[] parts = url.Split('/');

            string route = string.Join("/", parts.Take(3).ToArray());
            route = route.TrimEnd('/');

            string endpoint = "/" + string.Join("/", parts.Skip(3).ToArray());
            endpoint = endpoint.TrimEnd('/');

            var request = new Request(method, route, endpoint, headers, data, callback, _logLevel);
            BucketRequest(request);
        }

        private void BucketRequest(Request request)
        {
            foreach (var item in new List<Bucket>(buckets).Where(x => x.Disposed))
            {
                buckets.Remove(item);
            }

            var bucket = buckets.SingleOrDefault(x => x.Method == request.Method &&
                                                      x.Route == request.Route);

            if (bucket != null)
            {
                bucket.Queue(request);
                return;
            }

            var newBucket = new Bucket(request.Method, request.Route);
            buckets.Add(newBucket);

            newBucket.Queue(request);
        }
    }
}
