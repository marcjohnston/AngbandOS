namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultnethackMirrorVault : Vault
{
    private GreaterVaultnethackMirrorVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (nethack mirror)";
    public override int Category => 8;
    public override int Height => 22;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.......................................%%...............XXXX+XXXX...............%%...............X**X^X**X...............%%....XXXXXXXXXXXX**X^X**XXXXXXXXXXXX....%%....X^+99999999X+XX^XX+X99999999+^X....%%....X^X9*******X,,X^X,,X*******9X^X....%%....X^X9*******X,,X^X,,X*******9X^X....%%.XXXX+XXXXXXXXXXX+X+X+XXXXXXXXXXX+XXXX.%%.X**X,,,,,,,,,,X,,,,,,,X,,,,,,,,,,X**X.%%.X*@+,,,,,,,,,,+,,,,8,,X,,,,,,,,,,+@*X.%%.X*@+,,,,,,,,,,X,,,8,,,+,,,,,,,,,,+@*X.%%.X**X,,,,,,,,,,X,,,,,,,X,,,,,,,,,,X**X.%%.XXXX+XXXXXXXXXXX+X+X+XXXXXXXXXXX+XXXX.%%....X^X9*******X,,X^X,,X*******9X^X....%%....X^X9*******X,,X^X,,X*******9X^X....%%....X^+99999999X+XX^XX+X99999999+^X....%%....XXXXXXXXXXXX**X^X**XXXXXXXXXXXX....%%...............X**X^X**X...............%%...............XXXX+XXXX...............%%.......................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 41;
}
