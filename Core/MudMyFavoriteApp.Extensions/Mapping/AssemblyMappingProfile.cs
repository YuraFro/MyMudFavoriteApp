using AutoMapper;
using System.Reflection;

namespace MudMyFavoriteApp.Extensions.Mapping
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingFromAssembly(assembly);

        /// <summary>
        /// Сканируем сборку и ищем любой интерфейс реализующий <see cref="IMapWith{T}"/>
        /// </summary>
        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
