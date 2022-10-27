using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultserpentVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Lesser vault (serpent)";
    public override int Category => 7;
    public override int Height => 17;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..............................%%..##########################..%%.##...#.^.#.^.#...#...#.,.###.%%.#..#.*.#...#...#.^.#...#...+.%%.#.##########################.%%.#..#..#.,.#.^.#.^.#.*.#...##.%%.##^#.#..#...#...#...#...#..#.%%.#..#.####################..#.%%.#,##.&+,,,,,,,,,,,,,,,,,#*##.%%.#..##&+,,,,,,,,,,,,,,,,,#..#.%%.##^#######################.#.%%.#..#...#...#...#...#.^.#...#.%%.##...#.^.#.,.#.*.#.^.#...###.%%..##########################..%%..............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 32;
}
