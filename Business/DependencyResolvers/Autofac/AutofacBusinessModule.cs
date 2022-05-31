using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CargoManager>().As<ICargoService>().SingleInstance();
            builder.RegisterType<EfCargoDal>().As<ICargoDal>().SingleInstance();

            builder.RegisterType<CheckInManager>().As<ICheckInService>().SingleInstance();
            builder.RegisterType<EfCheckInDal>().As<ICheckInDal>().SingleInstance();

            builder.RegisterType<CheckOutManager>().As<ICheckOutService>().SingleInstance();
            builder.RegisterType<EfCheckOutDal>().As<ICheckOutDal>().SingleInstance();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            builder.RegisterType<MissionManager>().As<IMissionService>().SingleInstance();
            builder.RegisterType<EfMissionDal>().As<IMissionDal>().SingleInstance();

            builder.RegisterType<PortManager>().As<IPortService>().SingleInstance();
            builder.RegisterType<EfPortDal>().As<IPortDal>().SingleInstance();

            builder.RegisterType<ShipManager>().As<IShipService>().SingleInstance();
            builder.RegisterType<EfShipDal>().As<IShipDal>().SingleInstance();

            builder.RegisterType<StorageManager>().As<IStorageService>().SingleInstance();
            builder.RegisterType<EfStorageDal>().As<IStorageDal>().SingleInstance();

            builder.RegisterType<VehicleManager>().As<IVehicleService>().SingleInstance();
            builder.RegisterType<EfVehicleDal>().As<IVehicleDal>().SingleInstance();

            builder.RegisterType<WareHouseManager>().As<IWareHouseService>().SingleInstance();
            builder.RegisterType<EfWareHouseDal>().As<IWareHouseDal>().SingleInstance();

            builder.RegisterType<WorkingManager>().As<IWorkingService>().SingleInstance();
            builder.RegisterType<EfWorkingDal>().As<IWorkingDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();




            var assembly = System.Reflection.Assembly.GetExecutingAssembly();



            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
