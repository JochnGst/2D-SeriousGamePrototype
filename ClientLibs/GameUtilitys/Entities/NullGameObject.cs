using ClientFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilitys.Entities
{
    public class NullGameObject : IGameObject
    {
        private static NullGameObject? _instance = null;

        private NullGameObject()
        {

        }
        public static NullGameObject Create()
        {
            if (_instance is null)
                _instance = new NullGameObject();
            return _instance;
        }
    }
}
