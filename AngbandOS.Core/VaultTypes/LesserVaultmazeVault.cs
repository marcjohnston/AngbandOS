namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class LesserVaultmazeVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (maze)";
    public override int Category => 7;
    public override int Height => 22;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%.XXXXXXX............%%.XX,,.XXXXXXXXXXXXX.%%.XXXX*...&........X.%%.X.,,XXXXXXXXXXXX*X.%%.X.XXX.....*......X.%%.X..XX.XXXXXXXXXX.X.%%.XX.X.&.XX.X.....*X.%%.XX.XXX...*X,XXXX.^.%%.X.XX,XXXX.XXXX,XXX.%%.X.XX.....*..&.*X,X.%%.X.,XXXXXXXXXXX.X,X.%%.XXXX....*..X,X.X,X.%%.X....XXX.X.X.X.X.X.%%.X.XXXX,X.X.&.X.X.X.%%.X.X...*X.XXXXX.X.X.%%.X.X,XX&X....&..X.X.%%.X.XXXX.XXXXXXXXX.X.%%.X.....*...X*X*X..X.%%.XX^XXXXXX..X*X,XXX.%%........XXXXXXXXXXX.%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 22;
}
