﻿namespace PanteonGames.AdminSystem.Helper.Options
{
    public class MongoDbConfigOption
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;

    }

}
