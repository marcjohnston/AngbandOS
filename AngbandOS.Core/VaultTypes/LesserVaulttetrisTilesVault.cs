using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaulttetrisTilesVault : Vault
{
    public override char Character => '#';
    public override string Name => "Lesser vault (tetris tiles)";
    public override int Category => 7;
    public override int Height => 20;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%..#######..%%..#**#**#..%%..#,###,#..%%..#,#^#,#..%%.##+#^#+##.%%.#&,#^#,&#.%%.#,,+^+,,#.%%.####+####.%%.###,^,###.%%.#*##^##*#.%%.#,,#+#,,#.%%.##,#^#,##.%%.##+#^#+##.%%.#,,#^#,,#.%%.##,+^+,##.%%..#,#+#,#..%%..###.###..%%...........%%%%%%%%%%%%%%";
    public override int Width => 13;
}
