// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class TheIInTheStormVault : Vault
{
    private TheIInTheStormVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override string Name => "The I in the Storm";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 40;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXX#XXXXXXXXXXXXXXXXXXX%%X&&..^..#9X..^^^^^^^^^^^^^..X9#..^..&&X%%X&...#....X..XXXXXX^XXXXXX..X....#...&X%%X...&#..#.X9XX.@8XX^XX8@.XX9X.#..#&...X%%X..&9#....XXX...@X,,,X@...XXX....#9&..X%%X^####..#...XX..XX,.,XX..XX...#..####^X%%X........,#..XX^X,,.,,X^XX..#,........X%%X.......#.....^XX,...,XX^.....#.......X%%X........,#....X,,...,,X....#,........X%%X.......#.....XX.......XX.....#.......X%%X.#......,#..XX^.......^XX..#,......#.X%%X.9#....#....#^^...9...^^#....#....#9.X%%X.#......,#..XX^.......^XX..#,......#.X%%X.......#.....XX.......XX.....#.......X%%X........,#....X,,...,,X....#,........X%%X.......#.....^XX,...,XX^.....#.......X%%X........,#..XX^X,,.,,X^XX..#,........X%%X^####..#...XX..XX,.,XX..XX...#..####^X%%X..&9#....XXX...@X,,,X@...XXX....#9&..X%%X...&#..#.X9XX.@8XX^XX8@.XX9X.#..#&...X%%X&...#....X&&XXXXXX^XXXXXX&&X....#...&X%%X&&..^..#9X..^^^^^^^^^^^^^..X9#..^..&&X%%XXXXXXXXXXXXXXXXXXX#XXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 41;
}
