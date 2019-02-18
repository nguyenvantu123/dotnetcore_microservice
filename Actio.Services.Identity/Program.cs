using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Command;
using Actio.Common.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Actio.Services.Identity {
    public class Program {
        public static void Main (string[] args) {
            ServiceHost.Create<Startup> (args)
                .UseRabbitMq ()
                .SubscribleToCommand<CreateActivity> ()
                .Build ()
                .Run ();
        }
    }
}