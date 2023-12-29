using Microsoft.EntityFrameworkCore;
using Vb.Data;
using Vb.Data.Abstract;
using Vb.Data.Concrete;
using Vb.Data.Entity;
using VbApi.Abstract;
using VbApi.Concrete;

namespace VbApi;

public class Startup
{
    public IConfiguration Configuration;

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        string connection = Configuration.GetConnectionString("MsSqlConnection");
        services.AddDbContext<VbDbContext>(options => options.UseSqlServer(connection));
        //services.AddDbContext<VbDbContext>(options => options.UseNpgsql(connection));
        
        services.AddScoped<IGenericDal<Account>, GenericRepository<Account>>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddScoped<IGenericDal<AccountTransaction>, GenericRepository<AccountTransaction>>();
        services.AddScoped<IAccountTransactionService, AccountTransactionService>();
        
        services.AddScoped<IGenericDal<Address>, GenericRepository<Address>>();
        services.AddScoped<IAddressService, AddressService>();
        
        services.AddScoped<IGenericDal<Contact>, GenericRepository<Contact>>();
        services.AddScoped<IContactService, ContactService>();
        
        services.AddScoped<IGenericDal<EftTransaction>, GenericRepository<EftTransaction>>();
        services.AddScoped<IEftTransactionService, EftTransactionService>();
        
        services.AddControllers();
        
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    
    public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseEndpoints(x => { x.MapControllers(); });
    }
}
