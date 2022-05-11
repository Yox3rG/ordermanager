using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace FolderManipulator.FolderRelated
{
    static class UserIdentifier
    {
        public static string Identifier
        {
            get
            {
                if (string.IsNullOrEmpty(_identifier))
                    _identifier = UpdateMacAddress();
                return _identifier;
            }
        }

        private static string _identifier;

        public static string UpdateMacAddress()
        {
            try
            {
                string mac =
                    (
                    from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();
                return mac;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return null;
        }
    }
}
