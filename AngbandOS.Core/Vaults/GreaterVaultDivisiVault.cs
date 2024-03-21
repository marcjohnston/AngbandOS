// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultDivisiVault : Vault
{
    private GreaterVaultDivisiVault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Greater Vault (Divisi)";
    public override int Category => 8;
    public override int Height => 31;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.....................................................%%.#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#.%%.X,XX@@@&&,,,,,,,,,,,,,,,X8X,,,,,,,,,,,,,,,&&@@@XX,X.%%.X,,XXX@&&XXXXXXXXXXXXXX^X9X^XXXXXXXXXXXXXX&&@XXX,,X.%%.XX,,,XXX^^^XXX#8#8#8#8X^X@X^X8#8#8#8#XXX^^^XXX,,,XX.%%.XXXX,,,XXX^^^XXX######X^X&X^X######XXX^^^XXX,,,XXXX.%%.X@@XXX,,,XXX^^^XXX#8#8X^X,X^X8#8#XXX^^^XXX,,,XXX@@X.%%.X&&&&XXX,,,XXX^^^XX###X^X,X^X###XX^^^XXX,,,XXX&&&&X.%%.X^XX..#XXX,,,XXX^^^XXXX^X,X^XXXX^^^XXX,,,XXX#..XX^X.%%.X^.XXX#@@XXX,,,XXX^^^XX^X,X^XX^^^XXX,,,XXX@@#XXX.^X.%%.X^&&&XXX&&&XXX,,,XXX^^^^X,X^^^^XXX,,,XXX&&&XXX&&&^X.%%.X^XX&&&XXX^^^XXX,,,XXX^^X,X^^XXX,,,XXX^^^XXX&&&XX^X.%%.X,,XXX&@@XXX^^^XXX,,,XXX#,#XXX,,,XXX^^^XXX@@&XXX,,X.%%.X,,##XXX@##XXX^^^XXX,,,XX#XX,,,XXX^^^XXX##@XXX##,,X.%%.XXXX888XXX999XXX^^^###,#888#,###^^^XXX999XXX888XXXX.%%.X,,##XXX@##XXX^^^XXX,,,XX#XX,,,XXX^^^XXX##@XXX##,,X.%%.X,,XXX&@@XXX^^^XXX,,,XXX#,#XXX,,,XXX^^^XXX@@&XXX,,X.%%.X^XX&&&XXX^^^XXX,,,XXX^^X,X^^XXX,,,XXX^^^XXX&&&XX^X.%%.X^&&&XXX&&&XXX,,,XXX^^^^X,X^^^^XXX,,,XXX&&&XXX&&&^X.%%.X^.XXX#@@XXX,,,XXX^^^XX^X,X^XX^^^XXX,,,XXX@@#XXX.^X.%%.X^XX..#XXX,,,XXX^^^XXXX^X,X^XXXX^^^XXX,,,XXX#..XX^X.%%.X&&&&XXX,,,XXX^^^XX###X^X,X^X###XX^^^XXX,,,XXX&&&&X.%%.X@@XXX,,,XXX^^^XXX#8#8X^X,X^X8#8#XXX^^^XXX,,,XXX@@X.%%.XXXX,,,XXX^^^XXX######X^X&X^X######XXX^^^XXX,,,XXXX.%%.XX,,,XXX^^^XXX#8#8#8#8X^X@X^X8#8#8#8#XXX^^^XXX,,,XX.%%.X,,XXX@&&XXXXXXXXXXXXXX^X9X^XXXXXXXXXXXXXX&&@XXX,,X.%%.X,XX@@@&&,,,,,,,,,,,,,,,X8X,,,,,,,,,,,,,,,&&@@@XX,X.%%.#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#.%%.....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 55;
}
