// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackSamuraiCastle2Vault : Vault
{
    private GreaterVaultNethackSamuraiCastle2Vault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Name => "Greater vault (nethack samurai castle #2)";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...........................................................%%.XXXXXXXXXXXXX...............................XXXXXXXXXXXXX.%%.X,,^^^^^^^,,X...............................X,,^^^^^^^,,X.%%.X,,^XXXXX^,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,^XXXXX^,,X.%%.X,,^+999X^,,X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,X,,^X999+^,,X.%%.X,,^XXXXX^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^XXXXX^,,X.%%.X^^^^^^^^^^^XXXXXX+XXXXXXXXXXXXXXXXXXX+XXXXXX^^^^^^^^^^^X.%%.XXXX^^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^^XXXX.%%....+^^^X********+,,,,,,,,,,,,,,,,,,,,,,,+********X^^^+....%%....+^^^X********+,,,,,,,,,,,,,,,,,,,,,,,+********X^^^+....%%.XXXX^^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^^XXXX.%%.X^^^^^^^^^^^XXXXXX+XXXXXXXXXXXXXXXXXXX+XXXXXX^^^^^^^^^^^X.%%.X,,^XXXXX^,,^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^XXXXX^,,X.%%.X,,^+999X^,,X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,X,,^X999+^,,X.%%.X,,^XXXXX^,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,^XXXXX^,,X.%%.X,,^^^^^^^,,X...............................X,,^^^^^^^,,X.%%.XXXXXXXXXXXXX...............................XXXXXXXXXXXXX.%%...........................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 61;
}
