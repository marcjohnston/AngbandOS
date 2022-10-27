using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultprisonVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Lesser vault (prison)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.+..&..+..&..+..&..+..&..+..&..+.%%.###.#####.#####.#####.#####.###.%%.#,+.+,#,+.+,#,+.+,#,+.+,#,+.+,#.%%.###.#####.#####.#####.#####.###.%%.#,+.+,#,+.+,#,+.+,#,+.+,#,+.+,#.%%.###.#####.#####.#####.#####.###.%%.#,+.+,#,+.+,#,+.+,#,+.+,#,+.+,#.%%.###.#####.#####.#####.#####.###.%%.#,+.+,#,+.+,#,+.+,#,+.+,#,+.+,#.%%.###.#####.#####.#####.#####.###.%%.#,+.+,#,+.+,#,+.+,#,+.+,#,+.+,#.%%.###.#####.#####.#####.#####.###.%%&+..&..+..&..+..&..+..&..+..&..+.%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 35;
}
