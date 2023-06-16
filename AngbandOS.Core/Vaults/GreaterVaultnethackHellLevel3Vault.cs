// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultnethackHellLevel3Vault : Vault
{
    private GreaterVaultnethackHellLevel3Vault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (nethack hell level #3)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.....................................................%%...XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.........%%...X,,,,,,,,,,,,,,,,,,,,,XXX^^^^^^^^^^^^^^^X.........%%...X,^^^^^^^^^^XXXX,,,,,,+&&^XXXXXXXXXXXX^^+.........%%...X,^XXXXXX******X,,XXXXXXXXX^^^^******XXXX.........%%...X,^X****X@*XXXXXXXX,,,,,,,,,,,XXXXXXXXXXXXXX......%%.XXXX+X,,,,XXXX,,,,,,,,,,,,,,,,,^+************XXXXX..%%.X@,,,,,XX,,,,+,,XXXXXXXXXXXXXXXXX****9999****+888X..%%.XXXX+X,,,,XXXX,,,,,,,,,,,,,,,,,^+************XXXXX..%%...X,^X****X@*XXXXXXXX,,,,,,,,,,,XXXXXXXXXXXXXX......%%...X,^XXXXXX******X,,XXXXXXXXX^^^^******XXXX.........%%...X,^^^^^^^^^^XXXX,,,,,+&&^^XXXXXXXXXXXX^^+.........%%...X,,,,,,,,,,,,,,,,,,,,XXX^^^^^^^^^^^^^^^^X.........%%...XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.........%%.....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 55;
}
