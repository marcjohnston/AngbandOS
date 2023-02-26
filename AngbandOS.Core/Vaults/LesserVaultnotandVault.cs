namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultnotandVault : Vault
{
    private LesserVaultnotandVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault ('not' 'and')";
    public override int Category => 7;
    public override int Height => 11;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%.............%%..#########..%%.#+,,,#,,,+#.%%.#,#,#+#,#,#.%%.#,,#+*+#,,#.%%.#,#,#+#,#,#.%%.#+,,,#,,,+#.%%..#########..%%.............%%%%%%%%%%%%%%%%";
    public override int Width => 15;
}
