namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultSierpinskiVault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (Sierpinski)";
    public override int Category => 8;
    public override int Height => 28;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..................X..................%%.................XXX.................%%.................X8X.................%%.....&..........XX+XX................%%...............XX999XX........&......%%......&........X@X9X@X...............%%..............XXXX+XXXX..............%%.............XX*@*@*@*XX....&........%%.............X@X*@*@*X@X.............%%............XXXX**@**XXXX............%%..........&XX,,,X***X,,,XX&..........%%..........XX,X@X,X,X,X@X,XX..........%%.........XXXXX+XXXXXXX+XXXXX.........%%........XX+,,,,,,,,,,,,,,,+XX........%%........X@X,,,,,,,,,,,,,,,X@X........%%.......XX+XX,,,,,,,,,,,,,XX+XX.......%%......XX,,,XX,,,,,,,,,,,XX,,,XX......%%......X,X,X,X,,,,,,,,,,,X,X,X,X......%%.....XXXX+XXXX,,,,,,,,,XXXX+XXXX.....%%....XX*******XX,,,,,,,XX*******XX....%%....X,X*****X,X,,,,,,,X,X*****X,X....%%...XXXX*****XXXX,,,,,XXXX*****XXXX...%%..XX,,,X***X,,,XX,,,XX,,,X***X,,,XX..%%..X,X,X,X*X,X,X,X,,,X,X,X,X*X,X,X,X..%%.XXXXXXXX+XXXXXXXXXXXXXXXXX+XXXXXXXX.%%.........&.................&.........%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 39;
}
