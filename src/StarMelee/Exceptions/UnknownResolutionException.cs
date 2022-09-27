using System;

namespace StarMelee.Exceptions
{
    public class UnknownResolutionException : Exception
    {
        public UnknownResolutionException(string resolutionName) : base ($"Unknown resolution {resolutionName}")
        {
        }
    }
}