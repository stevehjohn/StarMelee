using StarMelee.Exceptions;
using StarMelee.Geometry;

namespace StarMelee.Infrastructure.Utilities
{
    public static class ResolutionResolver
    {
        public static (Size<int> Size, float XScale, float YScale) GetResolution(string resolutionName)
        {
            resolutionName = resolutionName.ToLowerInvariant();

            switch (resolutionName)
            {
                case "1440p":
                    return (new Size<int>(2560, 1440), 2560f / 1920f, 1440f / 1080f);

                case "1080p":
                    return (new Size<int>(1920, 1080), 1, 1);

                case "720p":
                    return (new Size<int>(1280, 720), 1280f / 1920f, 720f / 1080f);

                default:
                    throw new UnknownResolutionException(resolutionName);
            }
        }
    }
}