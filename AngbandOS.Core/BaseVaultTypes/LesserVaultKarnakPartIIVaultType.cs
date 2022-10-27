using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaultKarnakPartIIVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Lesser vault (Karnak, part II)";
    public override int Category => 7;
    public override int Height => 20;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%...........................%%.###+######################%%.#,+^#,,#,,#^+^+^#*#,#^+,#.%%.###.#,,#,,#^#^#^#*#,#^###.%%.#,+^#,,#,,#^#^#^#*#+#^+,#.%%.###.#++#++#^#^#^#+#.#^###.%%.#,+^#^^^^^+^#^#^+,,,#^+,#.%%.###.#^^^^^+^#^#+#+###^###.%%.#,+^#+#+#+#^#^#,#^+,#^+,#.%%.###.#,#,#,#^#^#######^###.%%.#,+^#######+#,,+,,,,,^+,#.%%.###^^^^^^#,^#,,+,,,,#^###.%%.#,+^#,#*^##+####,,,,,^+,#.%%.###^,,,*^#^^^^^#,,,,#^###.%%.#,+^#,#*^#,,,,^+,,,,,^+,#.%%.###^^^^^^#^^^^^#,,,,,^###.%%...##########+##########...%%...........................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 29;
}
