namespace AngbandOS.Core.Vaults;

[Serializable]
internal class RoundaboutTwoVault : Vault
{
    private RoundaboutTwoVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '#';
    public override string Name => "Roundabout Two";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 25;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%#^X.^^+X@XX.+X^^^^^+.X...X8#@&*X*****X%%X^X.^XX@XX.XX^^^^^^X.X.X^XXX@.&+9....X%%X^X.XX&XX.XX^^^^^^^X.X.X^X8#@&*X99...X%%X^X.X^^X&.XXXXXXXXXX.X.X^XXXXXXXXXX++X%%X^X.X.*X&.X.......&..X.X^X........X^^X%%X^X&X.*X^^X.XXXXXXXXXX.X&X#XXXXXX.X^.X%%X^X.X..X^^X...@........X.X......X.X^^X%%X^X.X..X^^XXXXXXXXXXXXXX.XXXXXX.X.X.^X%%X^X.X..X^^X..,.....,....&X8#,*X.X.X^^X%%X^X&X,,X^^X^XXXXXXXXXXXXXX##,,X.X.X^.X%%X^+&X..+^^X^^^^^^^^^^^^^^^9...#.X.#^^X%%X^X&X,,X^^X^XXXXXXXXXXXXXX##,*X.X.X.^X%%X^X.X..X^^X..,.....,....&X8#,,X.X.X^^X%%X^X.X..X^^XXXXXXXXXXXXXX.XXXXXX.X.X^.X%%X^X.X..X^^X...@........X.X......X.X^^X%%X^X&X.*X^^X.XXXXXXXXXX.X&X#XXXXXX.X.^X%%X^X.X.*X&.X.......&..X.X^X........X^^X%%X^X.X^^X&.XXXXXXXXXX.X.X^XXXXXXXXXX++X%%X^X.XX&XX.XX^^^^^^^X.X.X^X8#@&*X99...X%%X^X.^XX@XX.XX^^^^^^X.X.X^XXX@.&+9....X%%#^X.^^+X@XX.+X^^^^^+.X...X8#@&*X*****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 40;
}
