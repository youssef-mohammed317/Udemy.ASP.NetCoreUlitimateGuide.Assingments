using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksApp.BLL.Exceptions;

public class CustomValidationException : Exception
{
    public IReadOnlyDictionary<string, string[]> Errors { get; }

    public CustomValidationException(IReadOnlyDictionary<string, string[]> errors) : base("One or more validation failures have occured.")
    {
        Errors = errors;
    }
    public CustomValidationException(string propertyName, string msg) : base("One or more validation failures have occurred.")
    {
        Errors = new Dictionary<string, string[]>
        {
             { propertyName,  [ msg ] }
        };
    }
}
