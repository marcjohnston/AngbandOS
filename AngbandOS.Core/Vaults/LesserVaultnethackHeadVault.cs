namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultnethackHeadVault : Vault
{
    private LesserVaultnethackHeadVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (nethack, head)";
    public override int Category => 7;
    public override int Height => 17;
    public override int Rating => 7;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%........###########........%%...#####################...%%...######,,,,,,,,,######...%%..#+^^^^#,,,,,,,,,#^^^^+#..%%..##^^^^#,,,,,,,,,+^,,^##..%%.#####+##,,,,,,,,,#^^^^###.%%.##^^^^^^,,,,,,,,,########.%%.####+###++#########*@+*##.%%.##^^^^^#^^#,,,#^@^####*##.%%.##^^,,^#^^#,###^#^#****##.%%..##^,,^#^^#,,,.^#^#@####..%%..#+^^^^#^^#####^#^^^^^##..%%...######^^^^^^^^#######...%%...#####################...%%........###########........%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 29;
}
