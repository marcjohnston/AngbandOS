// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Vaults;

[Serializable]
internal class GreaterVaultTwistedCubeVault : Vault
{
    private GreaterVaultTwistedCubeVault(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<PoundSignSymbol>();
    public override string Name => "Greater Vault (Twisted Cube)";
    public override int Category => 8;
    public override int Height => 24;
    public override int Rating => 20;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.......................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.....%%.X...............................XX....%%.X..X^^XXXXXXXXXXXXXXXXXXXXX.XXX..#X...%%.X..XX^^XX,,,,,,,,,,,,,,,,,X.X&X+..XX..%%.X..X+X^^XX,,,,,,,,,,,,,,,,+.X9&XX..XX.%%.X..X,XX^^XXXXXXXXXXXXXXXXXX.XXXXXX..X.%%.X..X,,XX..................X.X.......X.%%.X..X,,,XX.XXXXXXXX#XXXXXXXX.XXXXXX..X.%%.X..X^^^^X.X,9,&***&,,,&***X.X****X..X.%%.X..X&&&&X.X9,&***&,8,&***&X.X^^^^X..X.%%.X..X^^^^X.X,&***&,8,&***&9X.X&&&&X..X.%%.X..X****X.X&***&,,,&***&9,X.X^^^^X..X.%%.X..XXXXXX.XXXXXXXX#XXXXXXXX.XX,,,X..X.%%.X.......X.X..................XX,,X..X.%%.X..XXXXXX.XXXXXXXXXXXXXXXXXX^^XX,X..X.%%.XX..XX&9X.+,,,,,,,,,,,,,,,,XX^^X+X..X.%%..XX..+X&X.X,,,,,,,,,,,,,,,,,XX^^XX..X.%%...X#..XXX.XXXXXXXXXXXXXXXXXXXXX^^X..X.%%....XX...............................X.%%.....XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.......................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 41;
}
