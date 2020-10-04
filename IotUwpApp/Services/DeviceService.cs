using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using IotUwpApp.Models;

namespace IotUwpApp.Services
{
    public static class DeviceService
    {
        public static Random rnd = new Random();
        public static string json;
        public static async Task SendMessageAsync(DeviceClient deviceClient)
        {
            json = JsonConvert.SerializeObject(new TemperatureModel(rnd.Next(10, 30), rnd.Next(0, 100)));
            var payload = new Message(Encoding.UTF8.GetBytes(json));
            await deviceClient.SendEventAsync(payload);
        }
    }
}
