﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AuthService
    {
        public static bool Authenticate(string uname, string pass)
        {
            return DataAccessFactory.AuthData().Authenticate(uname, pass);
        }
    }
}
