using System;
using System.Collections.Generic;
using System.Text;
using AppModels.ConfigModels;

namespace AppManager.AppInterfaces
{
    public interface ITokenProcessor
    {
        string createNewWebToken(JWTConfiguration jwtConfiguration);
    }
}
