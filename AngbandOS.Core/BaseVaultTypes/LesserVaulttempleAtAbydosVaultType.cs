using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LesserVaulttempleAtAbydosVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Lesser vault (temple at abydos)";
    public override int Category => 7;
    public override int Height => 21;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%^^^^^^^^^^^^^^^^^^^^^%%^#+#+#####+#####+#+#^%%^#,#,#^^^^^^^^^#,#,#^%%^#,#,#^#.#.#.#^#,#,#^%%^#,#,#^...&...^#,#,#^%%^#####^#.#.#.#^#####^%%^#*,,+^^^^^^^^^+,,*#^%%^#########+#########^%%^#*,,+^^^^^^^^^+,,*#^%%^#####^#.#.#.#^#####^%%^#*,,+^...&...^+,,*#^%%^#####^#.#.#.#^#####^%%^#*,,+^^^^^^^^^+,,*#^%%^##+###+##+##+###+##^%%^#,,,,#,#^^^#,#,,,,#^%%^#,##,#,#,#,#,#,##,#^%%^#,,,,#,#***#,#,,,,#^%%^###################^%%^^^^^^^^^^^^^^^^^^^^^%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 23;
}
