namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultAnotherNethackStyleCastleVault : Vault
{
    private GreaterVaultAnotherNethackStyleCastleVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Greater vault (another nethack-style castle)";
    public override int Category => 8;
    public override int Height => 18;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..................................................%%.XXXXX......................................XXXXX.%%.X9,,X......................................X,,9X.%%.XXX+XXXXXXXXXXXXXXXXXXX++XXXXXXXXXXXXXXXXXXX+XXX.%%...X^^^^^^^^^^^^^^^^^^^+..+^^^^^^^^^^^^^^^^^^^X...%%...X^XXXXXXXXXXXXXXXXXXX++XXXXXXXXXXXXXXXXXXX^X...%%...X^X,,,,,,,,,,,,,,,,,X..X,,,,,,,,,X,,@@@@,X^X...%%...X^X,,,,,,,,,,,,,,,,,+..+,,,,,,,,,+,,,,998X^X...%%...X^X,,,,,,,,,,,,,,,,,+..+,,,,,,,,,+,,,,998X^X...%%...X^X,,,,,,,,,,,,,,,,,X..X,,,,,,,,,X,,@@@@,X^X...%%...X^XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX^X...%%...X^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^X...%%.XXX+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+XXX.%%.X9,,X......................................X,,9X.%%.XXXXX......................................XXXXX.%%..................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 52;
}
