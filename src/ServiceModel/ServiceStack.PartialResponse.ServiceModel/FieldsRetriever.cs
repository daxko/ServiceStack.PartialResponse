using ServiceStack.Web;

namespace ServiceStack.PartialResponse.ServiceModel
{
    public static class FieldsRetriever
    {
        public static string GetFields(IRequest requestContext, IPartialResponseConfig partialResponseConfig)
        {
            switch (partialResponseConfig.FieldResolutionMethod)
            {
                case FieldResolutionMethod.HeaderOnly:
                    return FieldsFromHeader(requestContext, partialResponseConfig.FieldsHeaderName);
                case FieldResolutionMethod.QueryStringOnly:
                    return FieldsFromQueryString(requestContext, partialResponseConfig.FieldsQueryStringName);
                case FieldResolutionMethod.HeaderThenQueryString:
                {
                    string fields = FieldsFromHeader(requestContext, partialResponseConfig.FieldsHeaderName);
                    return string.IsNullOrWhiteSpace(fields)
                               ? FieldsFromQueryString(requestContext, partialResponseConfig.FieldsQueryStringName)
                               : fields;
                }
                case FieldResolutionMethod.QueryStringThenHeader:
                {
                    string fields = FieldsFromQueryString(requestContext, partialResponseConfig.FieldsQueryStringName);
                    return string.IsNullOrWhiteSpace(fields)
                               ? FieldsFromHeader(requestContext, partialResponseConfig.FieldsHeaderName)
                               : fields;
                }
                case FieldResolutionMethod.QueryStringAndHeader:
                {
                    string headerFields = FieldsFromHeader(requestContext, partialResponseConfig.FieldsHeaderName);
                    string queryFields = FieldsFromQueryString(
                        requestContext, partialResponseConfig.FieldsQueryStringName);
                    return string.IsNullOrWhiteSpace(headerFields)
                               ? queryFields
                               : string.Join(
                                   FieldSelectorConstants.MultipleFieldSeparator.ToString(), headerFields, queryFields);
                }
                default:
                    return string.Empty;
            }
        }

        public static string FieldsFromQueryString(IRequest requestContext, string fieldsQueryStringName)
        {
            if (requestContext.QueryString == null) return string.Empty;
            return requestContext.QueryString[fieldsQueryStringName] ?? string.Empty;
        }

        public static string FieldsFromHeader(IRequest requestContext, string fieldsHeaderName)
        {
            if (requestContext.Headers == null) return string.Empty;
            return requestContext.Headers[fieldsHeaderName] ?? string.Empty;
        }
    }
}