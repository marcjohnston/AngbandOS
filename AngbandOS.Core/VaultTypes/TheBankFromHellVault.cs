namespace AngbandOS.Core;

[Serializable]
internal class TheBankFromHellVault : Vault
{
    public override char Character => '#';
    public override string Name => "The Bank From Hell";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXX+XXXXXXXXXXXXXX%%X.&.&.&.&.&.#...#.&.&.&.&.&.X%%X.#.#.#.#.#.#...#.#.#.#.#.#.X%%X...........#...#...........X%%X##########+##+##+##########X%%X@........^^^^^^^^^........@X%%X@^^^.....^^^...^^^.....^^^@X%%X##+#######+#####+#######+##X%%X.^^^.#@..^^^...^^^..@#.^^^.X%%X#...##...............#.###.X%%X@...@#.&.&.&.&.&.&.&.#..@..X%%XXXXXXXXXXXXXXXXXXXXXXXXXXX+X%%X.+^*****X*******^+^******X.X%%X@X^....^X^......^X^.....*X@X%%X.X*****^+^*******X*******X.X%%X@XXXXXXXXXXXXXXXXXXXXXXXXX@X%%X.@.@.@.@.@.@.@.@.@.@.@.@.@.X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 31;
}
