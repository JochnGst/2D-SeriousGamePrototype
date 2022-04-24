using ClientFramework;
using ClientFramework.Attributes;
using ClientFramework.Interaction;
using System.Diagnostics;

namespace UserCode
{
    public class Main
    {
        private IPlayerAction _currentAction = Movement.Right;
        private bool _sawGameAsset = false;

        private int state = 0;

        public Main()
        {


        }

        public IPlayerAction Player_NextStep(ISurrounding surrounding)
        {
            switch (state)
            {
                case 0:
                    _currentAction = Movement.Right;
                    if (surrounding.Right is IGameAsset asset and ({ Type: null } or { Type: "" }))
                    {
                        state = 1;
                        _currentAction = new Installation { Target = asset, Station = new DrillFactory() };
                    }
                    break;
                case 1:
                    _currentAction = Movement.Left;
                    if (surrounding.CurrentPosition is IGameAsset { Type: "Start" })
                    {
                        state = 2;
                        _currentAction = Movement.Stay;
                    }
                    break;
                case 2:
                    _currentAction = Movement.Right;
                    if (surrounding.CurrentPosition is IGameAsset { Type: "Goal" })
                    {
                        _currentAction = Movement.Stay;
                        System.Console.WriteLine("Goal");
                    }
                    break;
                default:
                    _currentAction = Movement.Stay;
                    break;
            }

            return _currentAction;
        }

    }

    [Factory]
    public class DrillFactory : IStation
    {
        private readonly string _blockColor;

        public DrillFactory()
        {
        }

        [FactoryMethod(typeof(Drill))]
        public Drill CreateDrill()
        {
            return new Drill();
        }
    }


}
