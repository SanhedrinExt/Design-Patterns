using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace FacebookIntegrationExcercise
{
    class UserInfo
    {
        public string AccessToken { private set; get; }
        public Point Location { private set; get; }
        public Size Size { private set; get; }
        public bool AutoLogIn { private set; get; }
    }
}
