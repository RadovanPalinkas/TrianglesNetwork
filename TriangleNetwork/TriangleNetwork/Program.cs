using System;
using Unity;
namespace TriangleNetwork
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UnityContainer unityContainer = IocContainer.RegisterComponents())
            {
                unityContainer.Resolve<IAplication>().WriteTriangles();
            }

            Console.ReadKey();
        }
    }
}
