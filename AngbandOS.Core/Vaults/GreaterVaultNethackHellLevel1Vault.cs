// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackHellLevel1Vault : Vault
{
    private GreaterVaultNethackHellLevel1Vault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Greater vault (nethack hell level #1)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.....................................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.XX*XXXXXXXXXX**XXXXXXXXXXXX***********************X.%%.XX*X,,,,X***X+XX,,,,,,X***XXXXXXXXXXXX^^^^^^^^^^^^X.%%.XX,X,,,,+***X@^+,,,,,,X***+,,,,,,,,,,X^^^^^^^^^^^^X.%%.XX&X,,,,XXXXXXXX^^^^^^^^^^X,,,XXXXXXXXXXXXXX^^^^^^X.%%.XX+X....XXXX.............^X,,,+,,,,,,,,,,,9XXXXX^^X.%%.+^^^^^^^^^^+^^^^^^^^^^^^^^XXXXX,,,,,,,,,,,9+888+@@X.%%.XX+X....XXXX.............^X,,,+,,,,,,,,,,,9XXXXX^^X.%%.XX&X,,,,XXXXXXXX^^^^^^^^^^X,,,XXXXXXXXXXXXXX^^^^^^X.%%.XX,X,,,,+***X@^+,,,,,,X***+,,,,,,,,,,X^^^^^^^^^^^^X.%%.XX*X,,,,X***X+XX,,,,,,X***XXXXXXXXXXXX^^^^^^^^^^^^X.%%.XX*XXXXXXXXXX**XXXXXXXXXXXX***********************X.%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 55;
}
