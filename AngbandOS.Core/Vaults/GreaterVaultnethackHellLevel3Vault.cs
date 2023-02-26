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
