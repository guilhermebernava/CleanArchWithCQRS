using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using FluentValidation;
using System.Reflection;
using CleanArch.Application.Members.Commands.Validations;

namespace CleanArch.CrossCutting.AppDependencies;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var sqlServerConnection = configuration["Db"];
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(sqlServerConnection));

        services.AddSingleton<IDbConnection>(_ =>
        {
            var connection = new SqlConnection(sqlServerConnection);
            connection.Open();
            return connection;
        });

        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        var myHandlers = AppDomain.CurrentDomain.Load("CleanArch.Application");
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblies(myHandlers);
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.Load("CleanArch.Application"));
        return services;
    }
}
