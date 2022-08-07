using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;
using CleanArchMvc.Domain.Account;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Infra.Data.Identity;
using CleanArchMvc.Infra.Data.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
        {

            //Informar o tipo de Autenticação JWT-Bearer
            //Definir o modelo de desafio de Autenticação
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            
            //Habilita a autenticação JWT usando o esquema e desafios definidos
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true, 
                   ValidateIssuerSigningKey = true,

                   //Valores Validos
                   ValidIssuer = configuration["Jwt:Issuer"],
                   ValidAudience = configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                   ClockSkew = TimeSpan.Zero
            };
            });
            
            
            return services;

        }
    }
}
