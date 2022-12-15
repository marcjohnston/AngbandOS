namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultCentralVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser Vault (Central)";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 12;
    public override string Text => "%%%%%%%%%%%%%%%############%%#,#^^^^^^#,#%%##+######+##%%#^#^^,,^^#^#%%#^#^&@9&^#^#%%#^#^&9@&^#^#%%#^#^^,,^^#^#%%##+######+##%%#,#^^^^^^#,#%%############%%%%%%%%%%%%%%%";
    public override int Width => 14;
}
