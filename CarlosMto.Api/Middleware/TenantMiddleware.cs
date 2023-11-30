namespace CarlosMto.Api.Middleware
{
    public class TenantMiddleware
{
    private readonly RequestDelegate _next;

    public TenantMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string? tenant = context.Request.Path.HasValue
        ? context.Request.Path.Value.Split('/', StringSplitOptions.RemoveEmptyEntries).FirstOrDefault()
        : null;

            // Aquí podrías realizar validaciones o lógica adicional para verificar el tenant

            // Almacenar el tenant en el contexto para su uso posterior
            context.Items["Tenant"] = tenant;

        await _next(context);
    }
public         static string GetConnectionStringForTenant(string tenant)
        {
            switch (tenant)
            {
                case "tenant1":
                    return "ConnectionStringParaTenant1";
                case "tenant2":
                    return "ConnectionStringParaTenant2";
                // Agregar más casos según los tenants que manejes
                default:
                    throw new ArgumentException("Tenant no válido");
            }
        }
    }
}
