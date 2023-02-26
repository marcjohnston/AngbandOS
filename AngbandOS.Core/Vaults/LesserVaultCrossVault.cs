namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultCrossVault : Vault
{
    private LesserVaultCrossVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser Vault (Cross)";
    public override int Category => 7;
    public override int Height => 13;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%########++########%%#*....*#..#*....*#%%#....&,#^^#,&....#%%#....,##..##,....#%%#+#####*..*#####+#%%#^^.....,,.....^^#%%#+#####*..*#####+#%%#....,##..##,....#%%#....&,#^^#,&....#%%#*....*#..#*....*#%%########++########%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 20;
}
