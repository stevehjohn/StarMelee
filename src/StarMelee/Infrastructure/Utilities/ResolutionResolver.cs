using StarMelee.Exceptions;
using StarMelee.Geometry;

namespace StarMelee.Infrastructure.Utilities
{
    public static class ResolutionResolver
    {
        public static Size<int> GetResolution(string resolutionName)
        {
            resolutionName = resolutionName.ToLowerInvariant();

            switch (resolutionName)
            {
                case "1080p":
                    return new Size<int>(1920, 1080);

                default:
                    throw new UnknownResolutionException(resolutionName);
            }
        }
    }
}