using System;
using System.Collections.Generic;
using System.Text;

namespace AppManager.AppInterfaces
{
    public interface ITokenProcessor
    {
        string createNewWebToken();
        void ValidateWebToken();
    }
}
