﻿using KebabPiercingApi.Data;
namespace BookShop.Server.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
