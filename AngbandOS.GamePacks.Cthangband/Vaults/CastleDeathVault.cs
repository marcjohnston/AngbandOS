// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CastleDeathVault : VaultGameConfiguration
{
    public override string Name => "Castle Death";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,+XX....+XX...X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX....XXX....@X****X%%X.........................................XXX....&.@X****X%%X+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX....@.&.@X****X%%X999X..9..X&&&&&X,,,,,X@@@@@X..&..X@@@XXX....&.@.&.@X*99*X%%X@@@X.&.&.X&&&&&X,,,,,X@@@@@X99.99X9XXX.X..@.&.@.&.@X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...X..@.&.@.&.@XX##XX%%+^...&.&.&+...@.@.@+...@@@@@+.....99+...+..@.&.@.&.8+^^^^X%%+^...&.&.&+...@.@.@+...@@@@@+.....99+...+..@.&.@.&.8+^^^^X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...X..@.&.@.&.@XX##XX%%X@@@X.&.&.X&&&&&X,,,,,X@@@@@X99.99X9XXX.X..@.&.@.&.@X****X%%X999X..9..X&&&&&X,,,,,X@@@@@X..&..X@@@XXX....&.@.&.@X*99*X%%X+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX....@.&.@X****X%%X.........................................XXX....&.@X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX....XXX....@X****X%%X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,+XX....+XX...X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 60;
}
