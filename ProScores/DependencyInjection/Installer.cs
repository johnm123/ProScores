using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProScores.Logic;
using ProScores.Data;
namespace ProScores.DependencyInjection
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
            container.Register(Component.For<IResultManager>().ImplementedBy<ResultManager>());
            container.Register(Component.For<IProScoresDataStore>().ImplementedBy<ProScoresDataStore>());
            //container.Register(Component.For<IProScoresDataStore>().ImplementedBy<FakeProScoresDataStore>());
        }
    }
}