using CarlosMto.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CarlosMto.Api.Middleware
{
    public class TenantIdentificationMiddleware 
    {

        private readonly RequestDelegate _next;
        private readonly UserDbContext _userDbContext;
        private readonly ProductDbContext _productsDbContext;

        public TenantIdentificationMiddleware(RequestDelegate next,
               UserDbContext userDbContext,
               ProductDbContext productsDbContext)
        {
            _next = next;
            _userDbContext = userDbContext;
            _productsDbContext = productsDbContext;
        }

        public async Task Invoke(HttpContext context)
        {
            var tenant = context.Request.Path.Value.Split('/')[1];

            if (!string.IsNullOrEmpty(tenant))
            {
                // Setear tenantId en HttpContext para uso posterior
                context.Items["TenantId"] = tenant;
            }
            //DbContext selectedDbContext = null;
            //if (tenant == "organizations_users")
            //{
            //    selectedDbContext = _userDbContext;
            //}
            //else if (tenant == "products")
            //{
            //    selectedDbContext = _productsDbContext;
            //}

            // Llamar al siguiente middleware
            await _next(context);
        }

      
    }
}
