using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OfficePointApis.Helpers
{
    public static class ToastHelper
    {
        public static async Task<bool> SendPhoneCall(string displayName)
        {
            bool successful = false;

            try
            {
                string imageName = displayName.Replace(" ", "").Trim();

                var client = NotificationHubClient.CreateClientFromConnectionString("[ENTER YOUR HUB ZUMO HERE]", "[ENTER YOUR HUB NAME HERE]", true);
                string toast = "{ENTER YOUR TOAST PAYLOAD HERE]";
                
                await client.SendWindowsNativeNotificationAsync(toast);
                successful = true;
            }
            catch { }
            return successful;

        }
    }
}