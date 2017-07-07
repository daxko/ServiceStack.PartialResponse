namespace ServiceStack.PartialResponse.ServiceModel
{
    public interface IPropertyValueGetterFactory
    {
        IPropertyValueGetter CreatePropertyValueGetter(object instance, string propertyName);
    }
}