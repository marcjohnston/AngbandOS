// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GreaterVaultSierpinskiVault : VaultGameConfiguration
{
    public override string Name => "Greater vault (Sierpinski)";
    public override int Category => 8;
    public override int Height => 28;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%..................X..................%%.................XXX.................%%.................X8X.................%%.....&..........XX+XX................%%...............XX999XX........&......%%......&........X@X9X@X...............%%..............XXXX+XXXX..............%%.............XX*@*@*@*XX....&........%%.............X@X*@*@*X@X.............%%............XXXX**@**XXXX............%%..........&XX,,,X***X,,,XX&..........%%..........XX,X@X,X,X,X@X,XX..........%%.........XXXXX+XXXXXXX+XXXXX.........%%........XX+,,,,,,,,,,,,,,,+XX........%%........X@X,,,,,,,,,,,,,,,X@X........%%.......XX+XX,,,,,,,,,,,,,XX+XX.......%%......XX,,,XX,,,,,,,,,,,XX,,,XX......%%......X,X,X,X,,,,,,,,,,,X,X,X,X......%%.....XXXX+XXXX,,,,,,,,,XXXX+XXXX.....%%....XX*******XX,,,,,,,XX*******XX....%%....X,X*****X,X,,,,,,,X,X*****X,X....%%...XXXX*****XXXX,,,,,XXXX*****XXXX...%%..XX,,,X***X,,,XX,,,XX,,,X***X,,,XX..%%..X,X,X,X*X,X,X,X,,,X,X,X,X*X,X,X,X..%%.XXXXXXXX+XXXXXXXXXXXXXXXXX+XXXXXXXX.%%.........&.................&.........%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 39;
}
