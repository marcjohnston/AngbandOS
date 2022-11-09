using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultedfuVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (edfu)";
    public override int Category => 7;
    public override int Height => 15;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%.............%%.###########.%%.#,+^#,#^+,#.%%.###+#+#+###.%%.#,+^...^+,#.%%.###.###.###.%%.#,+.#*#.+,#.%%.###.#,#.###.%%.#,+.#^#.#,#.%%.###^...^#+#.%%.#,+,#+#,+,#.%%.#####^#####.%%.............%%%%%%%%%%%%%%%%";
    public override int Width => 15;
}
