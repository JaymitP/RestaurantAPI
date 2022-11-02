using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Supermarket.API.Extensions
{
    public static class ModelStateExtensions
    {
        public static ModelStateDictionary GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary; //.Select(m => new {m.Key, m.Value.Errors}).ToList();

        }
    }
}