using ClientFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilitys.Entities
{
    public class GameAsset : IGameObject, IGameAsset
    {
        public string? Type { get; set; }
        public IStation? Station { get; set; }
    }
}
