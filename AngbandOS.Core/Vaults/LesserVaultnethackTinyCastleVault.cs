namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultnethackTinyCastleVault : Vault
{
    private LesserVaultnethackTinyCastleVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (nethack, tiny castle)";
    public override int Category => 7;
    public override int Height => 14;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%................................%%.#####....................#####.%%.#*,&#....................#&,*#.%%.###+######################+###.%%...#,,,,,,,,,,,,,#,,,,,,,,,,#...%%...+,,,,,,,,,,,,,+,,,,,,,,,,+...%%...+,,,,,,,,,,,,,+,,,,,,,,,,+...%%...#,,,,,,,,,,,,,#,,,,,,,,,,#...%%.###+######################+###.%%.#*,&#....................#&,*#.%%.#####....................#####.%%................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 34;
}
