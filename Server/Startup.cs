﻿using AutoMapper;
using CRM_Server_Side.Controllers;
using CRM_Server_Side.Models.Database;
using CRM_Server_Side.Models.Mapping;
using CRM_Server_Side.Models.Repositories.Implementations;
using CRM_Server_Side.Models.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Server.Models.Repositories.Implementations;

namespace CRM_Server_Side;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
 
    public IConfiguration Configuration { get; }
 
    public void ConfigureServices(IServiceCollection services)
    {
        
        services.AddDbContext<ShopContext>(options =>
        {
            options.UseMySql(Configuration.GetConnectionString("Default"),new MySqlServerVersion(new Version(8, 0, 33)));
            //options.UseMySql(MySqlServerVersion.AutoDetect(Configuration.GetConnectionString("Default")));
        });

        services.AddTransient<IAddressRepository, AddressRepository>();
        services.AddTransient<ICardItemRepository, CardItemRepository>();
        services.AddTransient<ICardRepository, CardRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<IManufacturerRepository, ManufacturerRepository>();
        services.AddTransient<IProductInfoRepository, ProductInfoRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IProductTypeRepository, ProductTypeRepository>();
        services.AddTransient<ISalesRepository, SalesRepository>();
        services.AddTransient<ISuppliesRepository, SuppliesRepository>();
        services.AddTransient<IVisitedProductsByCustomerRepository, VisitedProductsByCustomerRepository>();
        
        
        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new ShopMapper());
        });

        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        
        
        services.AddControllers();
    }
 
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
 
        app.UseHttpsRedirection();
 
        app.UseRouting();
 
        app.UseAuthorization();
 
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}