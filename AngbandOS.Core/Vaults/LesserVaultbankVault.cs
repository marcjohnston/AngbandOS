namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultbankVault : Vault
{
    private LesserVaultbankVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (bank)";
    public override int Category => 7;
    public override int Height => 9;
    public override int Rating => 7;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.&XXXXXXXXXXXXXXXXX%%&&XXXXX+XXX+XX*,XXX%%&&+###########,*XXX%%.&XXX+XXX+XXX+XXXXX%%.&XXXXXXXXXXXXXXXXX%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
