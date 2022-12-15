namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultnethackTombVault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (nethack tomb)";
    public override int Category => 8;
    public override int Height => 13;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.......................................................%%..........XXXXX.XXXXX.XXXXX.XXXXX.XXXXX................%%..........X,,,X.X,,,X.X,,,X.X,,,X.X,,,X................%%.XXXXXXXXXX,&,XXX,&,XXX,&,XXX,&,XXX,&,XXXXXXXXXXXXXXXX.%%.X&^&X....^...^...^...^...^...^...^..^..X,,,,,,,,X,,9X.%%.+^^^+..^...^...^...^...^...^...^...^.@.+,,,,,,,,+,98X.%%.X&^&X....^...^...^...^...^...^...^.....X,,,,,,,,X,,9X.%%.XXXXXXXXXX,&,XXX,.,XXX,.,XXX,&,XXX,&,XXXXXXXXXXXXXXXX.%%..........X,,,X.X,,,X.X,,,X.X,,,X.X,,,X................%%..........XXXXX.XXXXX.XXXXX.XXXXX.XXXXX................%%.......................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 57;
}
