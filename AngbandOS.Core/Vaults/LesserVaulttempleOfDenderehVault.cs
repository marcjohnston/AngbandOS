namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaulttempleOfDenderehVault : Vault
{
    private LesserVaulttempleOfDenderehVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (temple of dendereh)";
    public override int Category => 7;
    public override int Height => 20;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%....................%%.##################.%%.#***+^&#**#&^+***#.%%.#***#^^#,,#^^#***#.%%.#####++#++#++#####.%%.#,,,+^^^^^^^^+,,,#.%%.#####^######^#####.%%.#,,,+^#,,,,#^+,,,#.%%.#####^#,**,#^#####.%%.#,,,+^#,**,#^#***#.%%.#####^#,**,#^#^^^#.%%.#,,,+^#,**,#^##+##.%%.#####^#,,,,#^#,,,#.%%.#,,,#^##++##^#&,&#.%%.#,,,+^^^^^^^^##+##.%%.#,,,#^^^^^^^^^^^^#.%%.########++########.%%....................%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 22;
}