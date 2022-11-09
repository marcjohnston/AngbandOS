using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultamadaTempleVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (amada temple)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%............................%%.######################.....%%.#**#,,,,+^^#.....&...#.....%%.#**#,,,,#^^#...&.....#.....%%.#+#######^^#..#.#.#.##.....%%.#,,,,,,,#^^#^^^^^^^^^#####.%%.#,,,,,,,+^^+^^^^^^^^^+^^^+.%%.#,,,,,,,#^^#^^^^^^^^^#####.%%.#+#######^^#..#.#.#.##.....%%.#**#,,,,#^^#...&..&..#.....%%.#**#,,,,+^^#.........#.....%%.######################.....%%............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 30;
}
