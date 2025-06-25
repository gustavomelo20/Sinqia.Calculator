using System.Text.RegularExpressions;

namespace Sinqia.Calculator.Api.Configurations;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        var str = value?.ToString();
        
        return string.IsNullOrEmpty(str)
            ? null
            : Regex.Replace(str, "([a-z])([A-Z])", "$1-$2").ToLower();
    }
}