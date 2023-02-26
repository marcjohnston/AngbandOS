namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultderElBahriSanctuaryVault : Vault
{
    private LesserVaultderElBahriSanctuaryVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (der el bahri sanctuary)";
    public override int Category => 7;
    public override int Height => 12;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%....................%%..........###.......%%..........#,#.......%%..###.###.#,#.......%%.##,###,###,#######.%%.+^^^^^^^+^^^+,,,,#.%%.+^^^^^^^+^^^+,,,,#.%%.######+###########.%%......###...........%%....................%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 22;
}
