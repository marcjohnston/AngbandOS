namespace AngbandOS.Core.Vaults;

[Serializable]
internal class FalseWallVault : Vault
{
    private FalseWallVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "False Wall";
    public override int Category => 8;
    public override int Height => 15;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%X+XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+X%%X^+^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^+^X%%X^XXXXXXXXXXXXXXXXXXXXXXXXXX+X##X+XXXXXXXXXXXXXXXXXXXXXXXXXX^X%%X^+@*&*@*&*@*&*@*&*@*&*@*&*@*X@@X*@*&*@*&*@*&*@*&*@*&*@*&*@+^X%%X^XXXXXXXXXXXXXXXXXXXXXXXXX+XX,,XX+XXXXXXXXXXXXXXXXXXXXXXXXX^X%%X^+&.@.&.@.&.@.&.@.&.@.&.@.&X*..*X&.@.&.@.&.@.&.@.&.@.&.@.&+^X%%X^XXXXXXXXXXXXXXXXXXXXXXXX+XX*..*XX+XXXXXXXXXXXXXXXXXXXXXXXX^X%%X^+,,,,,,,,,,,,,,,,,,,,,,,,X,,..,,X,,,,,,,,,,,,,,,,,,,,,,,,+^X%%X^XXXXXXXXXXXXXXXXXXXXXXX+XX##99##XX+XXXXXXXXXXXXXXXXXXXXXXX^X%%X^+&.@.&.@.&.@.&.@.&.@.&.@X..####..X@.&.@.&.@.&.@.&.@.&.@.&+^X%%X^XXXXXXXXXXXXXXXXXXXXXX+XX...##...XX+XXXXXXXXXXXXXXXXXXXXXX^X%%X^+*&*@*&*@*&*@*&*@*&*@*&X&@&@88&@&@X&*@*&*@*&*@*&*@*&*@*&*+^X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 64;
}
