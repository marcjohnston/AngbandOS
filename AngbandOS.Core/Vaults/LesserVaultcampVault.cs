namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultcampVault : Vault
{
    private LesserVaultcampVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (camp)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...................................%%.####^^^^^^^^^^^^^^^^^^^^^^^^^####.%%.#,&############+++############&,#.%%.###+.........................+###.%%.^#....##+#.....#+#....##+#....#^..%%.^+....#,,#.....#,#....#,,#....+^..%%.^+....+&&+..&..+&+..&.+&&+....+^..%%.^+....#,,#.....#,#....#,,#....+^..%%.^#....#+##.....#+#....#+##....#^..%%.###+.........................+###.%%.#,&############+++############&,#.%%.####^^^^^^^^^^^^^^^^^^^^^^^^^####.%%...................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 37;
}
