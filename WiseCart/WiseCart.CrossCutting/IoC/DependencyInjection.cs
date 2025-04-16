using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WiseCart.Application.DTOs.Validators;
using WiseCart.Application.Interfaces;
using WiseCart.Application.Mappings;
using WiseCart.Application.Services;
using WiseCart.Domain.Interfaces;
using WiseCart.Domain.Interfaces.Services;
using WiseCart.Infra.Repositories;
using WiseCart.Infra.Services;

namespace WiseCart.CrossCutting.IoC
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrasctructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IExternalProductApiRepository, ExternalProductApiRepository>();

            services.AddScoped<IShoppingRepository, ShoppingRepository>();
            services.AddScoped<IShoppingService, ShoppingService>();

            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IPurchaseService, PurchaseService>();

            services.AddScoped<IUnitOfMeasureRepository, UnitOfMeasureRepository>();
            services.AddScoped<IUnitOfMeasureService, UnitOfMeasureService>();

            services.AddScoped<IMarketRepository, MarketRepository>();
            services.AddScoped<IMarketService, MarketService>();

            services.AddScoped<ISecurityService, SecurityService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRepository<Type>, Repository<Type>>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            AddValidators(services);

            return services;
        }

        public static void AddValidators(IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<MarketDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<ProductDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<PurchaseDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<ShoppingDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<UnitOfMeasureDTOValidator>();
            services.AddValidatorsFromAssemblyContaining<UserDTOValidator>();

            services.AddFluentValidationAutoValidation();
        }
    }
}
