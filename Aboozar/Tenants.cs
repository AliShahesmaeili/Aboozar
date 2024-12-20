using Finbuckle.MultiTenant.Stores.InMemoryStore;
using Finbuckle.MultiTenant;

namespace Aboozar;

public static class Tenants
{
    public static readonly TenantInfo AliTenant = new()
    {
        Id = 1.ToString(),
        Name = "علی",
        Identifier = "ali",
    };

    public static readonly TenantInfo AboozarTenant = new()
    {
        Id = 2.ToString(),
        Name = "ابوذر",
        Identifier = "aboozar"
    };

    public static void Register(InMemoryStoreOptions<TenantInfo> options)
    {
        options.Tenants.Add(AliTenant);
        options.Tenants.Add(AboozarTenant);
    }

    public static Task<string?> GetStrategy(object state)
    {
        if (state is not HttpContext httpContext)
            return Task.FromResult<string?>(null);

        var tenantContext = httpContext.GetMultiTenantContext<TenantInfo>();

        if (tenantContext is not null && tenantContext.IsResolved)
            return Task.FromResult(tenantContext.TenantInfo!.Identifier);

        var port = httpContext.Connection.LocalPort;



        TenantInfo? tenantInfo = null;

        if (port == 7132)
            tenantInfo = AliTenant;
        else /*if (port == 7131)*/
            tenantInfo = AboozarTenant;


        return Task.FromResult(tenantInfo!.Identifier);
    }
}
