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
