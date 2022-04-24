using System;
using System.Collections.Generic;
using System.Text;

namespace ClientFramework.Interaction
{
    public class Installation : IPlayerAction
    {
        public IGameAsset Target { get; set; }
        public IStation Station { get; set; }
    }
}
