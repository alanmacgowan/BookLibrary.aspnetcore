
namespace BookLibrary.aspnetcore.UI.Infrastructure
{
    using BookLibrary.aspnetcore.Domain;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
    using System;

    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (typeof(IBaseEntity).IsAssignableFrom(context.Metadata.ModelType))
            {
                return new EntityModelBinder();
            }
            return null;
        }

    }
}
