namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultserpentVault : Vault
{
    private LesserVaultserpentVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (serpent)";
    public override int Category => 7;
    public override int Height => 17;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..............................%%..##########################..%%.##...#.^.#.^.#...#...#.,.###.%%.#..#.*.#...#...#.^.#...#...+.%%.#.##########################.%%.#..#..#.,.#.^.#.^.#.*.#...##.%%.##^#.#..#...#...#...#...#..#.%%.#..#.####################..#.%%.#,##.&+,,,,,,,,,,,,,,,,,#*##.%%.#..##&+,,,,,,,,,,,,,,,,,#..#.%%.##^#######################.#.%%.#..#...#...#...#...#.^.#...#.%%.##...#.^.#.,.#.*.#.^.#...###.%%..##########################..%%..............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 32;
}
