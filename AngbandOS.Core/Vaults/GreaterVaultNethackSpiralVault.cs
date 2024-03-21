// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackSpiralVault : Vault
{
    private GreaterVaultNethackSpiralVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
       public override string Name => "Greater vault (nethack spiral)";
    public override int Category => 8;
    public override int Height => 19;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.........XXXXXXXXX+XXXXXXXXX........%%......XXXX^^^^^^^^^^^^^^^^^XXXX.....%%...XXXX^^^^^XXXXXXXXXXXXX^^^^^XXXX..%%..XX^^^^^XXXX^^^^^^^^^^^XXXX^^^^^XX.%%.XX^^^^XXX^^^^XXXXXXXXX^^^^XXX^^^^XX%%.X^^^^XX^^^^XXX,^^^^^,XXX^^^^XX^^^^X%%.X,,,XX,,,XXX,,^XX+XX^,,XXX,,,XX,,,X%%.X,,,X,,,,X,,,^XX***XX^,,,X,,,,X,,,X%%.X,,,X,99,X,,,^+@888@+^,,,X,,,,+,,,X%%.X,,,X,,,,X,,,^XX***XX^,,,X,,,,X,,,X%%.X,,,XX,,,XXX,,^XX+XX^,,XXX,,,XX,,,X%%.X,,,,XX^^^^XXX,^^^^^,XXX^^^^XX,,,,X%%.XX,,,,XXX^^^^XXXX+XXXX^^^^XXX,,,,XX%%..XX,,,**XXXX^^^^^^^^^^^XXXX,,,,,XX.%%...XXXX**,,,XXXXXXXXXXXXX,,,,,XXXX..%%......XXXX,,,,,,,,,,,,,,,,,XXXX.....%%.........XXXXXXXXXXXXXXXXXXX........%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 38;
}
