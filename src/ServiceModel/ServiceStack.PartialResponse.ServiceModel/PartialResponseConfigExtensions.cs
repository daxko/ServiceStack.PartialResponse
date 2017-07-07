using System;
using System.Linq;

namespace ServiceStack.PartialResponse.ServiceModel
{
    public static class PartialResponseConfigExtensions
    {
        public static bool IsSupportedContentType(this IPartialResponseConfig partialResponseConfig, string contentType)
        {
            return
                !partialResponseConfig.SupportedResponseContentType.IsEmpty()
                && partialResponseConfig.SupportedResponseContentType.Any(
                    s => s.Equals(contentType, StringComparison.OrdinalIgnoreCase));
        }
    }
}