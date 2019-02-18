using System;
using Actio.Common.Command;
using Actio.Common.Event;
using Actio.Common.RabbitMq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RawRabbit;

namespace Actio.Common.Services {
    public class ServiceHost : IServiceHost {
        private readonly IWebHost _webhost;

        public ServiceHost (IWebHost webHost) => webHost = _webhost;

        public void Run () {
            throw new System.NotImplementedException ();
        }

        public static HostBuilder Create<TStartup> (string[] args) where TStartup : class {
            Console.Title = typeof (TStartup).Namespace;
            var config = new ConfigurationBuilder ()
                .AddEnvironmentVariables ()
                .AddCommandLine (args)
                .Build ();

            var hostBuilder = WebHost.CreateDefaultBuilder (args)
                .UseConfiguration (config)
                .UseStartup<TStartup> ();

            return new HostBuilder (hostBuilder.Build ());
        }

        public abstract class BuidlBase {
            public abstract ServiceHost Build ();
        }

        public class HostBuilder : BuidlBase {
            private readonly IWebHost _webhost;
            private IBusClient _busclient;

            public HostBuilder (IWebHost webHost) {
                webHost = _webhost;
            }

            public override ServiceHost Build () {
                 return new ServiceHost(_webhost);
            }

            public BusBuilder UseRabbitMq () {
                _busclient = (IBusClient) _webhost.Services.GetService (typeof (IBusClient));
                return new BusBuilder (_webhost, _busclient);
            }
        }

        public class BusBuilder : BuidlBase {

            private readonly IWebHost _webhost;
            private IBusClient _busclient;

            public BusBuilder (IWebHost webHost, IBusClient busclient) {
                _webhost = webHost;
                _busclient = busclient;
            }

            public override ServiceHost Build () {
                 return new ServiceHost(_webhost);
            }

            public BusBuilder SubscribleToCommand<TCommand>() where TCommand: ICommand 
            {
                var handler = (ICommandHandler<TCommand>)_webhost.Services.GetService(typeof(ICommandHandler<TCommand>));
                _busclient.WithCommandHandleAsync(handler);
                return this;
            }

             public BusBuilder SubscribleToEvent<TEvent>() where TEvent: IEvents
            {
                var handler = (IEventHandler<TEvent>)_webhost.Services.GetService(typeof(IEventHandler<TEvent>));
                _busclient.WithEventHandleAsync(handler);
                return this;
            }
        }
    }
}