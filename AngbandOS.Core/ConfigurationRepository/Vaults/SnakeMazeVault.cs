// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class SnakeMazeVault : Vault
{
    private SnakeMazeVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Snake Maze";
    public override int Category => 8;
    public override int Height => 21;
    public override int Rating => 15;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%.....................%%.XXXXXXXXX+XXXXXXXXX.%%.X9X9..XXX..X,,,9X9X.%%.X,XXX.^.XX.X,XXXX,X.%%.X,,,XXX..X.X,,,,X,X.%%.XXX,,,XX.X.XX*X,,,X.%%.X...X*X..X.XXXXXX.X.%%.X.XXXXX.XX.X.^.X..X.%%.X...^........X.X.XX.%%.X#XXXXXXXXXXXX...*X.%%.X&.........^&XX.XXX.%%.X.XXXXXXXXXX.XX,,,X.%%.X.X......^...*XXX,X.%%.X.X,XXXXXXXX&XX,,,X.%%.X.X,XX9,,,,X&9X,XXX.%%.X^X,,XXXXX.XXXX,X*X.%%.X.XX99XX**......^.X.%%.X+XXXXXXXXXXXXXXXXX.%%.....................%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 23;
}
