namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultlesserCryptVault : Vault
{
    private LesserVaultlesserCryptVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (lesser crypt)";
    public override int Category => 7;
    public override int Height => 13;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%................###.....%%................#,#.....%%......#######.###+###...%%..###.#,#,#,#.#^^^^^#...%%.##&###+#+#+###^###^###.%%.+^^^+^^^^^^^+^^#9#^+,#.%%.##&###+#+#+###^###^###.%%..###.#,#,#,#.#^^^^^#...%%......#######.###+###...%%................#,#.....%%................###.....%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 26;
}
