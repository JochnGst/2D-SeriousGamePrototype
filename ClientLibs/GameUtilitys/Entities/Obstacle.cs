using ClientFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilitys.Entities
{
    public class Obstacle : IGameObject
    {
        private static Obstacle? _instance = null;

        private Obstacle()
        {

        }
        public static Obstacle Create()
        {
            if (_instance is null)
                _instance = new Obstacle();
            return _instance;
        }
    }
}
