using BookLibrary.aspnetcore.Services.Implementations;
using BookLibrary.aspnetcore.Services.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using System;
using BookLibrary.aspnetcore.Domain;

namespace BookLibrary.aspnetcore.UI.Infrastructure
{
    public class EntityModelBinder : IModelBinder
    {

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var modelName = bindingContext.BinderModelName;
            if (string.IsNullOrEmpty(modelName))
            {
                modelName = "id";
            }

            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            int id = 0;
            if (!int.TryParse(value, out id))
            {
                bindingContext.ModelState.TryAddModelError(bindingContext.ModelName, "Id must be an integer.");
                return;
            }

            var entity = await GetModel(bindingContext, id);
            bindingContext.Result = ModelBindingResult.Success(entity);
        }

        private async Task<object> GetModel(ModelBindingContext bindingContext, int id)
        {
            var serviceProvider = bindingContext.HttpContext.RequestServices;
            if (bindingContext.ModelType == typeof(Book))
            {
                var service = serviceProvider.GetService<IBookService>();
                return await service.Get(id);
            }
            else if (bindingContext.ModelType == typeof(Author))
            {
                var service = serviceProvider.GetService<IAuthorService>();
                return await service.Get(id);
            }
            else if (bindingContext.ModelType == typeof(Publisher))
            {
                var service = serviceProvider.GetService<IPublisherService>();
                return await service.Get(id);
            }
            return null;
        }


    }
}
