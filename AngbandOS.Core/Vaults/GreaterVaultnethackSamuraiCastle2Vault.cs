namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultnethackSamuraiCastle2Vault : Vault
{
    private GreaterVaultnethackSamuraiCastle2Vault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (nethack samurai castle #2)";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...........................................................%%.XXXXXXXXXXXXX...............................XXXXXXXXXXXXX.%%.X,,^^^^^^^,,X...............................X,,^^^^^^^,,X.%%.X,,^XXXXX^,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,^XXXXX^,,X.%%.X,,^+999X^,,X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,X,,^X999+^,,X.%%.X,,^XXXXX^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^XXXXX^,,X.%%.X^^^^^^^^^^^XXXXXX+XXXXXXXXXXXXXXXXXXX+XXXXXX^^^^^^^^^^^X.%%.XXXX^^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^^XXXX.%%....+^^^X********+,,,,,,,,,,,,,,,,,,,,,,,+********X^^^+....%%....+^^^X********+,,,,,,,,,,,,,,,,,,,,,,,+********X^^^+....%%.XXXX^^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^^XXXX.%%.X^^^^^^^^^^^XXXXXX+XXXXXXXXXXXXXXXXXXX+XXXXXX^^^^^^^^^^^X.%%.X,,^XXXXX^,,^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^XXXXX^,,X.%%.X,,^+999X^,,X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,X,,^X999+^,,X.%%.X,,^XXXXX^,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,^XXXXX^,,X.%%.X,,^^^^^^^,,X...............................X,,^^^^^^^,,X.%%.XXXXXXXXXXXXX...............................XXXXXXXXXXXXX.%%...........................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 61;
}
