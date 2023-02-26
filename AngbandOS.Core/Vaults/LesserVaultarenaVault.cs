namespace AngbandOS.Core.Vaults;

[Serializable]
internal class LesserVaultarenaVault : Vault
{
    private LesserVaultarenaVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Lesser vault (arena)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%...............%%.+###########+.%%.#...........#.%%.#.####^####.#.%%.#.#,,,,,,,#.#.%%.#.#,,,,,,,#.#.%%.#.^,,,,,,,^.#.%%.#.#,,,,,,,#.#.%%.#.#,,,,,,,#.#.%%.#.####^####.#.%%.#...........#.%%.+###########+.%%...............%%%%%%%%%%%%%%%%%%";
    public override int Width => 17;
}
