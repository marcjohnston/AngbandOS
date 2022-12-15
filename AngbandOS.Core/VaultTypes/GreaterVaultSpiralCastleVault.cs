namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultSpiralCastleVault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (Spiral castle)";
    public override int Category => 8;
    public override int Height => 31;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%.......................%%.XXXXX...........XXXXX.%%.X,,,X...........X,,,X.%%.X,,,X...........X,,,X.%%.XXX+XXXXXXXXXXXXX+XXX.%%...X^^^^^^^^^^^^^^^X...%%...X^XXXXXXXXXXXXX^X...%%...X^X^^^^^^^^^^^+^X...%%...X^X^XXXXXXXXXXX^X...%%...X^X^X&..&....&X^X...%%...X^X^X.XXXXXXX.X^X...%%...X^X^X.X^^^^^X.X^X...%%...X^X^X&X+XXX^X.X^X...%%...X^X^X.X*9*X^X&X^X...%%...+^X^X,X989X^X.X^+...%%...X^X^X.X*9*X^X.X^X...%%...X^X^X.XXX+X^X,X^X...%%...X^X^X..&..X^X.X^X...%%...X^X.XXXXXXX^X.X^X...%%...X^X^^^^^^^^^X&X^X...%%...X^XXXXXXXXXXX.X^X...%%...X^+...&..&...,X^X...%%...X^XXXXXXXXXXXXX^X...%%...X^^^^^^^^^^^^^^^X...%%.XXX+XXXXXXXXXXXXX+XXX.%%.X,,,X...........X,,,X.%%.X,,,X...........X,,,X.%%.XXXXX...........XXXXX.%%.......................%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 25;
}
