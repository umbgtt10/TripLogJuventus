using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripLog.Services;
using TripLog.UWP.Services;

namespace TripLog.UWP.Modules
{
    public class TripLogPlatformModule : NinjectModule
    {
        public override void Load()
        {
            Bind<GeoLocationService>().
                To<UwpLocationService>().
                InSingletonScope();
        }
    }
}
