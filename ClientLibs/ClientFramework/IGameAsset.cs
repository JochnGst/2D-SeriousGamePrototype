namespace ClientFramework
{
    public interface IGameAsset
    {
        string Type { get; set; }

        IStation Station { get; set; }
    }
}