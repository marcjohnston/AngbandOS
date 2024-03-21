// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultmazeVault : Vault
{
    private LesserVaultmazeVault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Lesser vault (maze)";
    public override int Category => 7;
    public override int Height => 22;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%.XXXXXXX............%%.XX,,.XXXXXXXXXXXXX.%%.XXXX*...&........X.%%.X.,,XXXXXXXXXXXX*X.%%.X.XXX.....*......X.%%.X..XX.XXXXXXXXXX.X.%%.XX.X.&.XX.X.....*X.%%.XX.XXX...*X,XXXX.^.%%.X.XX,XXXX.XXXX,XXX.%%.X.XX.....*..&.*X,X.%%.X.,XXXXXXXXXXX.X,X.%%.XXXX....*..X,X.X,X.%%.X....XXX.X.X.X.X.X.%%.X.XXXX,X.X.&.X.X.X.%%.X.X...*X.XXXXX.X.X.%%.X.X,XX&X....&..X.X.%%.X.XXXX.XXXXXXXXX.X.%%.X.....*...X*X*X..X.%%.XX^XXXXXX..X*X,XXX.%%........XXXXXXXXXXX.%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 22;
}
