using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrdersWebApi.CustomExceptions;

public class CustomValidationException : Exception
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public CustomValidationException(IReadOnlyDictionary<string, string[]> errors) : base("One or more error occurred.")
    {
        Errors = errors;
    }
    public CustomValidationException(string propertyName, string message) : base("One or more error occurred.")
    {
        Errors = new Dictionary<string, string[]>
        {
            { propertyName, [message] }
        };
    }

}
public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string ResourceName) : base($"resource : {ResourceName} - missing")
    {
    }
}
