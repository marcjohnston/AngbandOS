namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultcelticVault : Vault
{
    private LesserVaultcelticVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (celtic)";
    public override int Category => 7;
    public override int Height => 17;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.#####..#+#..#####.%%.#&,##.##&##.##,&#.%%.#+##..#*^*#..##+#.%%.#....###.###....#.%%...####..&..####...%%.###*##.#+#.##*###.%%.+&.^..&+*+&..^.&+.%%.###*##.#+#.##*###.%%...####..&..####...%%.#....###.###....#.%%.#+##..#*^*#..##+#.%%.#&,##.##&##.##,&#.%%.#####..#+#..#####.%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
