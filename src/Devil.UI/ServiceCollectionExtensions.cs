using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace Devil.UI;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Extension Method to setup all the TPIE.UI Dependencies.
    /// </summary>
    /// <param name="services">The Service Collection for DI.</param>
    /// <param name="config">The configuration.</param>
    /// <returns></returns>
    public static IServiceCollection SetupDevilUI(this IServiceCollection services)
        => services.AddBlazorise(options =>
        {
            options.Immediate = true;
        })
        .Replace(ServiceDescriptor.Transient<IComponentActivator, ComponentActivator>())
        .AddBootstrap5Providers()
        .AddFontAwesomeIcons();
}
