using Gmail.UIAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gmail.Tests
{
    public class HookInitialize : TestInitializtionHooks
    {
        public HookInitialize() : base(BrowserType.Chrome)
        {
            InitializeSetting();
            NavigateSite();
        }
    }
}
