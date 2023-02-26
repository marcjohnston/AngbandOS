namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultzelaznyVault : Vault
{
    private LesserVaultzelaznyVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (zelazny)";
    public override int Category => 7;
    public override int Height => 18;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%.................%%.###############.%%.+,,,,,,,,,,,,,#.%%.###########,,,#.%%.#,,,,+..##,,,##.%%.#,,,##.##,,,##..%%.#,*##.##,,,##...%%.#&##.##,,,##.##.%%.###.##,,,##.###.%%.##.##,,,##.##&#.%%...##,,,##.##*,#.%%..##,,,##..+,,,#.%%.##,,,##########.%%.#,,,,,,,,,,,,,+.%%.###############.%%.................%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 19;
}
