// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class TheBankFromHellVault : Vault
{
    private TheBankFromHellVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(PoundSignSymbol));
    public override string Name => "The Bank From Hell";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXX+XXXXXXXXXXXXXX%%X.&.&.&.&.&.#...#.&.&.&.&.&.X%%X.#.#.#.#.#.#...#.#.#.#.#.#.X%%X...........#...#...........X%%X##########+##+##+##########X%%X@........^^^^^^^^^........@X%%X@^^^.....^^^...^^^.....^^^@X%%X##+#######+#####+#######+##X%%X.^^^.#@..^^^...^^^..@#.^^^.X%%X#...##...............#.###.X%%X@...@#.&.&.&.&.&.&.&.#..@..X%%XXXXXXXXXXXXXXXXXXXXXXXXXXX+X%%X.+^*****X*******^+^******X.X%%X@X^....^X^......^X^.....*X@X%%X.X*****^+^*******X*******X.X%%X@XXXXXXXXXXXXXXXXXXXXXXXXX@X%%X.@.@.@.@.@.@.@.@.@.@.@.@.@.X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 31;
}
