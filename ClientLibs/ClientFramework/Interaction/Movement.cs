namespace ClientFramework.Interaction
{
    public class Movement : IPlayerAction
    {
        public static readonly Movement Right = new Movement(1);
        public static readonly Movement Left = new Movement(-1);
        public static readonly Movement Stay = new Movement(0);
        public float XDirection { get; }

        private Movement(float xDirection)
        {
            XDirection = xDirection;
        }
    }
}
