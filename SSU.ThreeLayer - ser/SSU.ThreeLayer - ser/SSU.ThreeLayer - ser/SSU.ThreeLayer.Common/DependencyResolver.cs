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
        private static IBaseClients baseClients;
        private static IClientLogic clientLogic;
        private static IBasePerson basePerson;
        private static IPersonLogic personLogic;

        public static IBaseClients BaseClients
        {
            get => baseClients ?? (baseClients = new BaseClients());
        }

        public static IClientLogic ClientLogic
        {
            get => clientLogic ?? (clientLogic = new ClientLogic(BaseClients));
        }

        public static IBasePerson BasePerson
        {
            get => basePerson ?? (basePerson = new BasePerson());
        }

        public static IPersonLogic PersonLogic
        {
            get => personLogic ?? (personLogic = new PersonLogic(BasePerson));
        }
    }
}