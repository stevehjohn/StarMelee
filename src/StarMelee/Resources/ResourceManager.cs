using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using StarMelee.Exceptions;

namespace StarMelee.Resources
{
    public class ResourceManager
    {
        private readonly Dictionary<string, string> _resources;

        private static readonly Lazy<ResourceManager> Lazy = new Lazy<ResourceManager>(GetResources);

        public static ResourceManager Instance => Lazy.Value;

        private ResourceManager()
        {
        }

        public ResourceManager(Dictionary<string, string> resources)
        {
            _resources = resources;
        }

        public string GetResource(string key)
        {
            if (! _resources.TryGetValue(key, out var resource))
            {
                throw new UnknownResourceException(key);
            }

            return resource;
        }

        private static ResourceManager GetResources()
        {
            var json = File.ReadAllText("Resources\\default.json");

            return new ResourceManager(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
        }
    }
}