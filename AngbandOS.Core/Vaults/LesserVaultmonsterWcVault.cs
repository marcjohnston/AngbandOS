namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultmonsterWcVault : Vault
{
    private LesserVaultmonsterWcVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (monster wc)";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%..#######.%%..#.&&&&#.%%..#^#####.%%.##...+,#.%%.#*...###.%%.#*...+,#.%%.#*...###.%%.##...+,#.%%..#+#####.%%..........%%%%%%%%%%%%%";
    public override int Width => 12;
}
