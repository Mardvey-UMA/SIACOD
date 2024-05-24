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
        private static IBaseTelephoneGuide basePerson;
        private static ITelephon_guide personLogic;

        public static IBaseClients BaseClients
        {
            get => baseClients ?? (baseClients = new BaseClients());
        }

        public static IClientLogic ClientLogic
        {
            get => clientLogic ?? (clientLogic = new ClientLogic(BaseClients));
        }

        public static IBaseTelephoneGuide BasePerson
        {
            get => basePerson ?? (basePerson = new BaseTelephoneGuide());
        }

        public static ITelephon_guide PersonLogic
        {
            get => personLogic ?? (personLogic = new Telephon_guide_logic(BasePerson));
        }
    }
}