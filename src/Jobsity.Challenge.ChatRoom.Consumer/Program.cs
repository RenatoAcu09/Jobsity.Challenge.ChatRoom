using Jobsity.Challenge.ChatRoom.Consumer;
using Jobsity.Challenge.ChatRoom.Consumer.Infra.Configuration;
using Jobsity.Challenge.ChatRoom.Consumer.Infra.Gateways;
using Jobsity.Challenge.ChatRoom.Consumer.Interfaces.Gateways;
using Jobsity.Challenge.ChatRoom.Core.Utils;
using System.Net.Http.Headers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        // Add configurations.
        services.AddSingleton(hostContext.Configuration.Get<DataAppSettings>());

        services.AddHttpClient(NamedHttpClients.Chat)
            .ConfigureHttpClient(
                client =>
                {
                    client.BaseAddress = new Uri(hostContext.Configuration.Get<DataAppSettings>().ChatApiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                })
            .AddTransientHttpErrorPolicy(HttpUtils.PollyConfiguration());

        services.AddSingleton<IChatGateway, ChatGateway>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();