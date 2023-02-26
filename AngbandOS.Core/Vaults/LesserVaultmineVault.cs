namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultmineVault : Vault
{
    private LesserVaultmineVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (mine)";
    public override int Category => 7;
    public override int Height => 9;
    public override int Rating => 7;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.XXXXXXXXXXXXXXXXXX%%.XX##XXXX*,,XX,*,XX%%.*#XX,*##X*#XX***XX%%.XXXX*,XXXXX##,*,XX%%.XXXXXXXXXXXXXXXXXX%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
