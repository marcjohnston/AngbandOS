using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultlayersVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Lesser vault (layers)";
    public override int Category => 7;
    public override int Height => 21;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.########+########.%%.#.......,.......#.%%.#.#############.#.%%.#.#....+.#*...#.#.%%.#.#.####+####.#.#.%%.#.#.#...&...#.#.#.%%.#.#.#.#####.#.#.#.%%.#.#.#.#*,*#.#.#.#.%%.#^#^#^#,,,#^#^#.#.%%.#.#.#.#*,*#.#.#.#.%%.#.#.#.##+##.#.#.#.%%.#.#.#..+,#*.#.#.#.%%.#.#.#########.#.#.%%.#.#.....,.....#.#.%%.#.######+######.#.%%.#.....*#.+......#.%%.#################.%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
