// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LesserVaultlayersVault : VaultGameConfiguration
{
    public override string Name => "Lesser vault (layers)";
    public override int Category => 7;
    public override int Height => 21;
    public override int Rating => 5;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%...................%%.########+########.%%.#.......,.......#.%%.#.#############.#.%%.#.#....+.#*...#.#.%%.#.#.####+####.#.#.%%.#.#.#...&...#.#.#.%%.#.#.#.#####.#.#.#.%%.#.#.#.#*,*#.#.#.#.%%.#^#^#^#,,,#^#^#.#.%%.#.#.#.#*,*#.#.#.#.%%.#.#.#.##+##.#.#.#.%%.#.#.#..+,#*.#.#.#.%%.#.#.#########.#.#.%%.#.#.....,.....#.#.%%.#.######+######.#.%%.#.....*#.+......#.%%.#################.%%...................%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 21;
}
