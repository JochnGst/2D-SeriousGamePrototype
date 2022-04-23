using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientFramework
{
    public interface ISurrounding
    {
        IGameObject Up { get;  }
        IGameObject UpRight { get;  }
        IGameObject Right { get; }
        IGameObject DownRight { get;  }
        IGameObject Down { get;  }
        IGameObject DownLeft { get;  }
        IGameObject Left { get;  }
        IGameObject UpLeft { get;  }
        IGameObject CurrentPosition { get;  }
    }
}
