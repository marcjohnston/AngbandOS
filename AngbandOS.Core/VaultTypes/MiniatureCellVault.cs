namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class MiniatureCellVault : Vault
{
    public override char Character => '#';
    public override string Name => "Miniature Cell";
    public override int Category => 7;
    public override int Height => 5;
    public override int Rating => 5;
    public override string Text => "%%%%%%#8#%%888%%#8#%%%%%%";
    public override int Width => 5;
}
