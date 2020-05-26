using Ninject.Modules;

namespace EventAdmin.Models
{
    public class DIModule : NinjectModule
    {
        private string ObjectName;
        public DIModule(string name)
        {
            ObjectName = name;
        }
        public override void Load()
        {
            switch (ObjectName)
            {
                case "DbContext":
                    Bind<ApplicationDbContext>().To<ApplicationDbContext>();
                    break;
                default:
                    break;
            }
        }
    }
}