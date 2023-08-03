// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultNethackLargeCityVault : Vault
{
    private GreaterVaultNethackLargeCityVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Greater vault (nethack, large city)";
    public override int Category => 8;
    public override int Height => 21;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%....................................................%%.##################################################.%%.#................................................#.%%.#.####################.########..#####.#########.#.%%.#.#^,,,,^#^****^#^,,^#.#^,,,,^#..#^^^#.#^,,,,,^#.#.%%.#.#^,,,,^#^****^#^,,^#.#^,,,,^#..+^**#.#^,,,,,^#.#.%%.#.#^,,,,^#^,,,,^#^^^^#.#^^^^^^#..#^^^#.#^,,,,,^#.#.%%.#.#^^^^^^#^^^^^^###+##.###+####..#####.#^^^^^^^#.#.%%.#.#+#########+###......................######+##.#.%%.#................................................#.%%.#.###+######+####......###+########..............#.%%.#.#^^^^^^#^^^^^^######.#^^^^^^^^^^#...###+#####..#.%%.#.#^,,,,^#^,,,,^#^^^^+.#^,,,,,,,,^#...#^^^^^^^#..#.%%.#.#^****^#^,,,,^#,,,^#.#^@999999@^#...#^,,,,,^#..#.%%.#.#^****^#^,,,,^#,,,^#.#^^^^^^^^^^#...#^,,,,,^#..#.%%.+.####################.############...#########..#.%%.#................................................#.%%.##################################################.%%....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 54;
}
