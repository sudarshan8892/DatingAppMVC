﻿using Microsoft.EntityFrameworkCore.Migrations;
using WebAPIDatingAPP.DATA.migration;

namespace WebAPIDatingAPP.Entities
{
    public class AppUsers
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }   
        public byte[] PasswordSalt { get; set; }    

}
}

