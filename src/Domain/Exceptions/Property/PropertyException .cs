
namespace Domain.Exceptions.Property;

public class PropertyNotFoundException : Exception
{
    public PropertyNotFoundException(Guid propertyId)
        : base($"The property with ID '{propertyId}' was not found.")
    {
    }
}

public class PropertyCreateException : Exception
{
    public PropertyCreateException(string message) : base(message)
    {
    }
}

public class PropertyFilterException : Exception
{
    public PropertyFilterException(string message) : base(message)
    {
    }
}

public class InvalidPropertyException : Exception
{
    public InvalidPropertyException(string message) : base(message)
    {
    }
}
