using System.Reflection;
using FluentValidation;
using Module = Autofac.Module;
using Survey_Project.Core.Repositories;
using Survey_Project.Core.Services;
using Survey_Project.Core.UnitOfWorks;
using Survey_Project.Service.Services;
using Autofac;
using Core.Repositories;
using Survey_Project.Service.Mapping;
using Repository.Repositories;
using Repository.UnitOfWorks;

namespace Survey_Project.API.Modules
{
    public class RepositoryServicesModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(GenericService<>)).As(typeof(IGenericService<>)).InstancePerLifetimeScope();


            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<AnswerRepository>().As<IAnswerRepository>();
            builder.RegisterType<QuestionRepository>().As<IQuestionRepository>();

  
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<AnswerService>().As<IAnswerService>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
         


            builder.RegisterType<UnitOfWork>().As<IGenericUnitOfWork>();

            var repository =  Assembly.GetAssembly(typeof(AppContext));
            var service = Assembly.GetAssembly(typeof(MapProfiles));
            var api = Assembly.GetExecutingAssembly();


            builder.RegisterAssemblyTypes(repository, service, api).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(repository, service, api).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();


        }
    }
}
