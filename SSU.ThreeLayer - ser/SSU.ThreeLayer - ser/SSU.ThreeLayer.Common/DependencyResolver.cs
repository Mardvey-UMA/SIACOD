using SSU.ThreeLayer.BLL;
using SSU.ThreeLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSU.ThreeLayer.Common
{
    public static class DependencyResolver
    {
        static private IBaseClients baseClients;
        static private IClientLogic clientLogic;

        static public IBaseClients BaseClients
        {
            get => baseClients ?? (baseClients = new BaseClients());

        }
        static public IClientLogic ClientLogic
        {
            get => clientLogic ?? 
            (clientLogic = new ClientLogic(BaseClients));
        }


     }
}
