namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class LesserVaultarenaVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (arena)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%...............%%.+###########+.%%.#...........#.%%.#.####^####.#.%%.#.#,,,,,,,#.#.%%.#.#,,,,,,,#.#.%%.#.^,,,,,,,^.#.%%.#.#,,,,,,,#.#.%%.#.#,,,,,,,#.#.%%.#.####^####.#.%%.#...........#.%%.+###########+.%%...............%%%%%%%%%%%%%%%%%%";
    public override int Width => 17;
}
