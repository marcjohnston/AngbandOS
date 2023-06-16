// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultnethackBuildingVault : Vault
{
    private GreaterVaultnethackBuildingVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (nethack building)*";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%....................................................%%........XXXXXXXXXXXXX.................XXXXXXXXXXXXX.%%........X***********X.................X***********X.%%.XXXXXXXX***********XXXXXXXXXXXXXXXXXXX***********X.%%.+^^^^^^X,,,,,,,,,,,X**X**X**X**X**X**X*,,,,,,,,,*X.%%.X^,,,,^X^,,,,,,,,,,X,@X,@X,@X,@X,@X,@X,,,,,,,,,,,X.%%.X^^^^^^+^^^^^^^^^^^XX+XX+XX+XX+XX+XX+X,,,,,,,,,,,X.%%.XXXXXXXX^^^^^^^^^^^+^^^^^^^^^^^^^^^^^+,,,,,89,,,,X.%%.X^^^^^^+^^^^^^^^^^^XX+XX+XX+XX+XX+XX+X,,,,,98,,,,X.%%.X^,,,,^X^,,,,,,,,,,X,@X,@X,@X,@X,@X,@X,,,,,,,,,,,X.%%.+^^^^^^X,,,,,,,,,,,X**X**X**X**X**X**X*,,,,,,,,,*X.%%.XXXXXXXX***********XXXXXXXXXXXXXXXXXXX***********X.%%........X***********X.................X***********X.%%........XXXXXXXXXXXXX.................XXXXXXXXXXXXX.%%....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 54;
}
