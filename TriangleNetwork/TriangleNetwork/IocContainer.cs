using Unity;
using TriangleNetwork.Calculators;
using TriangleNetwork.DataLayer;
using TriangleNetwork.Models;

//Unity Container pro Dependenci Injection obsahujer registraci komponent

namespace TriangleNetwork
{
    public class IocContainer
    {
        public static UnityContainer RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IAplication, Aplication>();
            container.RegisterType<IDataRepository, DataRepository>();
            container.RegisterType<IDataValidator, DataValidator>();        
            container.RegisterType<IService, FileService>();
            container.RegisterType<ICalculator, Calculator>();
            container.RegisterType<IColumns, Columns>();
            container.RegisterType<ITriangle, Triangle>();
            container.RegisterType<IError, Error>();
            container.RegisterType<IPoint, Point>();
            container.RegisterType<ICalculationPreparer, CalculationPreparer>();

            return container;
        }
    }
}
