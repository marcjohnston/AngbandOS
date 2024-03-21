// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class RoundaboutTwoVault : Vault
{
    private RoundaboutTwoVault(Game game) : base(game) { } // This object is a singleton.
    public override string Name => "Roundabout Two";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%#^X.^^+X@XX.+X^^^^^+.X...X8#@&*X*****X%%X^X.^XX@XX.XX^^^^^^X.X.X^XXX@.&+9....X%%X^X.XX&XX.XX^^^^^^^X.X.X^X8#@&*X99...X%%X^X.X^^X&.XXXXXXXXXX.X.X^XXXXXXXXXX++X%%X^X.X.*X&.X.......&..X.X^X........X^^X%%X^X&X.*X^^X.XXXXXXXXXX.X&X#XXXXXX.X^.X%%X^X.X..X^^X...@........X.X......X.X^^X%%X^X.X..X^^XXXXXXXXXXXXXX.XXXXXX.X.X.^X%%X^X.X..X^^X..,.....,....&X8#,*X.X.X^^X%%X^X&X,,X^^X^XXXXXXXXXXXXXX##,,X.X.X^.X%%X^+&X..+^^X^^^^^^^^^^^^^^^9...#.X.#^^X%%X^X&X,,X^^X^XXXXXXXXXXXXXX##,*X.X.X.^X%%X^X.X..X^^X..,.....,....&X8#,,X.X.X^^X%%X^X.X..X^^XXXXXXXXXXXXXX.XXXXXX.X.X^.X%%X^X.X..X^^X...@........X.X......X.X^^X%%X^X&X.*X^^X.XXXXXXXXXX.X&X#XXXXXX.X.^X%%X^X.X.*X&.X.......&..X.X^X........X^^X%%X^X.X^^X&.XXXXXXXXXX.X.X^XXXXXXXXXX++X%%X^X.XX&XX.XX^^^^^^^X.X.X^X8#@&*X99...X%%X^X.^XX@XX.XX^^^^^^X.X.X^XXX@.&+9....X%%#^X.^^+X@XX.+X^^^^^+.X...X8#@&*X*****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
