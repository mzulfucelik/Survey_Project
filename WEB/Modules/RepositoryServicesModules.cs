using System.Reflection;
using FluentValidation;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Survey_Project.Core.DTOs;
using Survey_Project.Service.Exceptions;
using System.Text.Json;
using System.Linq;
using Module = Autofac.Module;
using Autofac.Extensions.DependencyInjection;
using Repository.Repositories;
using Survey_Project.Core.Repositories;
using Survey_Project.Core.Services;
using Survey_Project.Core.UnitOfWorks;
using Survey_Project.Service.Mapping;
using Survey_Project.Service.Services;
using Autofac;
using Core.Models;
using Core.Repositories;
using Repository.UnitOfWorks;

namespace Survey_Project.WEB.Modules
{
    public class RepositoryServicesModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>();
            builder.RegisterType<AnswerRepository>().As<IAnswerRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
         


          
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<AnswerService>().As<IAnswerService>();
            builder.RegisterType<UserService>().As<IUserService>();


            builder.RegisterType<UnitOfWork>().As<IGenericUnitOfWork>();

            var repository =  Assembly.GetAssembly(typeof(AppContext));
            var service = Assembly.GetAssembly(typeof(MapProfiles));
            var api = Assembly.GetExecutingAssembly();


            builder.RegisterAssemblyTypes(repository, service, api).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(repository, service, api).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}
