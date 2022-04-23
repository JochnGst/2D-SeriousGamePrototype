using ClientFramework;
using ClientFramework.Attributes;
using System.Diagnostics;

namespace UserCode
{
    public class Main
    {
        private Movement _currentDirection = Movement.Right;

        public Main()
        {


        }

        public Movement Player_NextStep(ISurrounding surrounding)
        {
            if (surrounding.Right is IGameAsset { Type: "Goal" })
            {
                System.Console.WriteLine("Goal");
            }

            return _currentDirection;
        }
    }

    //[Factory]
    //public class DrillFactory : IStation
    //{
    //    private readonly string _blockColor;

    //    public DrillFactory()
    //    {
    //    }

    //    [FactoryMethod(typeof(Drill))]
    //    public Drill CreateDrill()
    //    {
    //        return new Drill();
    //    }
    //}


}
