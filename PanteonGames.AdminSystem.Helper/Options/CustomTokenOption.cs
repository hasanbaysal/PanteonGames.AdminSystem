﻿namespace PanteonGames.AdminSystem.Helper.Options
{
    public class CustomTokenOption
    {

        public string Audience { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokenExpiration { get; set; }
        public string SecurityKey { get; set; } = null!;
    }

}
