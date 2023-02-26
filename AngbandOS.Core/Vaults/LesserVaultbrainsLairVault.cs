namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultbrainsLairVault : Vault
{
    private LesserVaultbrainsLairVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (brain's lair)";
    public override int Category => 7;
    public override int Height => 18;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%...............%%.#############.%%.#...........#.%%.#.####^####.#.%% #.#...&...#.#.%%.#.#.#####.#.#.%%.#.#.#,,,#.#.#.%%.#.#.#,,,#.#.#.%%.#.#.#,,,#.#.#.%%.#.#.##+##.#.#.%%.^.#..#^#..#.^.%%.####.#^#.####.%%.#,,#.#+#.#,,#.%%.#,,+..&..+,,#.%%.#############.%%...............%%%%%%%%%%%%%%%%%%";
    public override int Width => 17;
}
