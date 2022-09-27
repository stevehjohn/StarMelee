using System;

namespace StarMelee.Exceptions
{
    public class UnknownResourceException : Exception
    {
        public UnknownResourceException(string resourceKey) : base ($"Unknown resource key {resourceKey}")
        {
        }
    }
}