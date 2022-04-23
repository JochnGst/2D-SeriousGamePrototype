using ClientFramework;
using GameUtilitys.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameUtilitys.Utilities
{
    public class PlayerSurrounding : ISurrounding
    {

        public IGameObject? Up { get;  }
        public IGameObject? UpRight { get;  }
        public IGameObject? Right { get;  }
        public IGameObject? DownRight { get;  }
        public IGameObject? Down { get;  }
        public IGameObject? DownLeft { get;  }
        public IGameObject? Left { get;  }
        public IGameObject? UpLeft { get;  }
        public IGameObject? CurrentPosition { get;  }

        public PlayerSurrounding()
        {
            Up = null;
            UpRight = null;
            Right = null;
            DownRight = null;
            Down = null;
            DownLeft = null;
            Left = null;
            UpLeft = null;
            CurrentPosition = null;
        }

        public PlayerSurrounding(IGameObject up, IGameObject upRight, IGameObject right, IGameObject downRight, IGameObject down, IGameObject downLeft, IGameObject left, IGameObject upLeft, IGameObject currentPosition)
        {
            Up = up;
            UpRight = upRight;
            Right = right;
            DownRight = downRight;
            Down = down;
            DownLeft = downLeft;
            Left = left;
            UpLeft = upLeft;
            CurrentPosition = currentPosition;
        }

    }
}
