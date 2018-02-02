using System;
using LendFoundry.Foundation.Services.Settings;

namespace Message.Api
{
    public class Settings
    {
        private const string Prefix = "RS_MESSAGE";

        public static string ServiceName { get; } = Prefix.ToLower();

        // Not used currently (Copied over from sample project)
        public static ServiceSettings EventHub { get; } = 
            new ServiceSettings($"{Prefix}_EVENTHUB_HOST", "eventhub", $"{Prefix}_EVENTHUB_PORT");

        public static ServiceSettings Identity { get; } =
            new ServiceSettings($"{Prefix}_IDENTITY_HOST", "identity", $"{Prefix}_IDENTITY_PORT");

        // Not used currently (Copied over from sample project)
        public static ServiceSettings Configuration { get; } = 
            new ServiceSettings($"{Prefix}_CONFIGURATION_HOST", "configuration", $"{Prefix}_CONFIGURATION_PORT");

        public static ServiceSettings Tenant { get; } = 
            new ServiceSettings($"{Prefix}_TENANT", "tenant", $"{Prefix}_TENANT_PORT");

        // Not used currently (Copied over from sample project)
        public static ServiceSettings AddressManager { get; } = 
            new ServiceSettings($"{Prefix}_ADDRESSMANAGER_HOST", "address-manager", $"{Prefix}_ADDRESSMANAGER_PORT");

        // Not used currently (Copied over from sample project)
        public static ServiceSettings Lookup { get; } = 
            new ServiceSettings($"{Prefix}_LOOKUP_HOST", "address-manager", $"{Prefix}_LOOKUP_PORT");

        // Not used currently (Copied over from sample project)
        public static string Nats => 
            Environment.GetEnvironmentVariable($"{Prefix}_NATS_URL") ?? "nats://nats:4222";

        public static string MongoConnectionString { get; } = 
            Environment.GetEnvironmentVariable($"{Prefix}_MONGO_CONNECTION") ?? "mongodb://localhost:27017";

        public static string MongoDatabase { get; } = 
            Environment.GetEnvironmentVariable($"{Prefix}_MONGO_DATABASE") ?? "rs-message-db";
    }
}
