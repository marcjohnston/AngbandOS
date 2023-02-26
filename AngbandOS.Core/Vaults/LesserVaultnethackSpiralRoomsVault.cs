namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultnethackSpiralRoomsVault : Vault
{
    private LesserVaultnethackSpiralRoomsVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (nethack, spiral rooms)";
    public override int Category => 7;
    public override int Height => 13;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..............................%%....#######################...%%..###^+,,,,,,#^^^^^^^^^^+*###.%%..#,#^#,,,,,,#+############,#.%%..#^#^#,,,,,,#,,,+,,,,,,#^#^#.%%..+^+^#,,,,,,#,,,#,,,,,,#^+^+.%%..#^#^#,,,,,,+,,,#,,,,,,#^#^#.%%..#,############+#,,,,,,#^#,#.%%..###*+^^^^^^^^^^#,,,,,,+^###.%%....#######################...%%..............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 32;
}
