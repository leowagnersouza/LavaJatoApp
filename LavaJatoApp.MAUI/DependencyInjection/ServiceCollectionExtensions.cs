using System.Reflection;
using LavaJatoApp.MAUI.Pages;
using LavaJatoApp.MAUI.ViewModels;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LavaJatoApp.MAUI.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        Assembly assembly = typeof(MauiProgram).Assembly;

        RegisterViewModels(services, assembly);
        RegisterPages(services, assembly);

        return services;
    }

    private static void RegisterViewModels(IServiceCollection services, Assembly assembly)
    {
        IEnumerable<Type> viewModelTypes = assembly
            .GetTypes()
            .Where(type =>
                type is { IsClass: true, IsAbstract: false }
                && !type.ContainsGenericParameters
                && type.BaseType == typeof(BaseViewModel));

        foreach (Type type in viewModelTypes)
        {
            services.TryAdd(ServiceDescriptor.Transient(type, type));
        }
    }

    private static void RegisterPages(IServiceCollection services, Assembly assembly)
    {
        IEnumerable<Type> pageTypes = assembly
            .GetTypes()
            .Where(type =>
                type is { IsClass: true, IsAbstract: false }
                && !type.ContainsGenericParameters
                && type.BaseType?.IsGenericType == true
                && type.BaseType.GetGenericTypeDefinition() == typeof(BasePage<>));

        foreach (Type type in pageTypes)
        {
            services.TryAdd(ServiceDescriptor.Transient(type, type));
        }
    }
}

