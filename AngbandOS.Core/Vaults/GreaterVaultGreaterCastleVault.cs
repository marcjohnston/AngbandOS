// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultGreaterCastleVault : Vault
{
    private GreaterVaultGreaterCastleVault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Greater vault (greater castle)";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 40;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.................................................%%...XXXXXX...............................XXXXXX...%%..XX,,,,XX.............................XX,,,,XX..%%.XX,*99*,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,*99*,XX.%%.XX,*99*,+^^^^^^^^^^^^^^^^^^^^^^^^^^^^^+,*99*,XX.%%..XX,,,,XXXXXXXXXXXXXXX+X+XXXXXXXXXXXXXXX,,,,XX..%%...XX++XX...............X...............XX++XX...%%....X^^X.............XXXXXXX.............X^^X....%%....X^^X.X^^^^^^^^^^^^^^^^^^^^^^^^^^^^^X.X^^X....%%....X^^X.X^^^XXXXXXXXXXXXXXXXXXXXXXX^^^X.X^^X....%%....X^^+&X^^XX@.+***************+.@XX^^X&+^^X....%%....X^^XXX^^+@.@X*9999988899999*X@.@+^^XXX^^X....%%....X^^+.X^^XX@.+***************+.@XX^^X.+^^X....%%....X^^X.X^^^XXXXXXXXXXXXXXXXXXXXXXX^^^X.X^^X....%%....X^^X.X^^^^^^^^^^^^^^^^^^^^^^^^^^^^^X.X^^X....%%....X^^X............XXXX+XXXX............X^^X....%%...XX++XX..........XX&.&.&.&XX..........XX++XX...%%..XX,,,,XXXXXXXXXXXX&.&.&.&.&XXXXXXXXXXXX,,,,XX..%%.XX,*99*,+********9XXXXX+XXXXX9********+,*99*,XX.%%.XX,*99*,XXXXXXXXXXX&.&.&.&.&XXXXXXXXXXX,*99*,XX.%%..XX,,,,XX.........XX&.&.&.&XX.........XX,,,,XX..%%...XXXXXX...........XXXX+XXXX...........XXXXXX...%%.................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 51;
}
