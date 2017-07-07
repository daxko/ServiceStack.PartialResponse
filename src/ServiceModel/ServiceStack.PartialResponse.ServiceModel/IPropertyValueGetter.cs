namespace ServiceStack.PartialResponse.ServiceModel
{
    public interface IPropertyValueGetter
    {
        object GetPropertyValue(object instance);
        string PropertyName { get; }
    }
}