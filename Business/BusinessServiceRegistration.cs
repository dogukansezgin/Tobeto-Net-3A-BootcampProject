using Business.Abstracts.Applicants;
using Business.Abstracts.Applications;
using Business.Abstracts.ApplicatonStates;
using Business.Abstracts.Blacklists;
using Business.Abstracts.BootcampImages;
using Business.Abstracts.Bootcamps;
using Business.Abstracts.BootcampStates;
using Business.Abstracts.Employees;
using Business.Abstracts.InstructorImages;
using Business.Abstracts.Instructors;
using Business.Abstracts.Users;
using Business.Concretes.Applicants;
using Business.Concretes.Applications;
using Business.Concretes.ApplicationStates;
using Business.Concretes.Blacklists;
using Business.Concretes.BootcampImages;
using Business.Concretes.Bootcamps;
using Business.Concretes.BootcampStates;
using Business.Concretes.Employees;
using Business.Concretes.InstructorImages;
using Business.Concretes.Instructors;
using Business.Concretes.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddScoped<IApplicantService, ApplicantManager>();
        services.AddScoped<IApplicationService, ApplicationManager>();
        services.AddScoped<IApplicationStateService, ApplicationStateManager>();
        services.AddScoped<IBlacklistService, BlacklistManager>();
        services.AddScoped<IBootcampImageService, BootcampImageManager>();
        services.AddScoped<IBootcampService, BootcampManager>();
        services.AddScoped<IBootcampStateService, BootcampStateManager>();
        services.AddScoped<IEmployeeService, EmployeeManager>();
        services.AddScoped<IInstructorService, InstructorManager>();
        services.AddScoped<IInstructorImageService, InstructorImageManager>();
        services.AddScoped<IUserService, UserManager>();

        services.AddScoped<IApplicantValidator, ApplicantValidator>();
        services.AddScoped<IApplicationValidator, ApplicationValidator>();
        services.AddScoped<IApplicationStateValidator, ApplicationStateValidator>();
        services.AddScoped<IBlacklistValidator, BlacklistValidator>();
        services.AddScoped<IBootcampValidator, BootcampValidator>();
        services.AddScoped<IBootcampStateValidator, BootcampStateValidator>();
        services.AddScoped<IEmployeeValidator, EmployeeValidator>();
        services.AddScoped<IInstructorValidator, InstructorValidator>();
        services.AddScoped<IUserValidator, UserValidator>();

        return services;
    }
}
