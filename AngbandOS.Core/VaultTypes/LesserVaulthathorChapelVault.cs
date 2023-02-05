namespace AngbandOS.Core.VaultTypes;

[Serializable]
internal class LesserVaulthathorChapelVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (hathor chapel)";
    public override int Category => 7;
    public override int Height => 21;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%.................%%......##+###.....%%.######^^^######.%%.#,,#^#...#^#,,#.%%.#,,+^..*..^+,,#.%%.#,,#^#...#^#,,#.%%.####^.....^####.%%....#^^^^^^^#....%%....#.##+##.#....%%....#&#^^^#&#....%%....###,^,###....%%....#,,,,,,,#....%%....####+####....%%....#,,,,,,,#....%%....####+####....%%....#,,,,,,,#....%%....####+####....%%.....#*****#.....%%.....#######.....%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 19;
}
