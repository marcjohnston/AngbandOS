using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CastleDeathVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Castle Death";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,+XX....+XX...X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX....XXX....@X****X%%X.........................................XXX....&.@X****X%%X+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX....@.&.@X****X%%X999X..9..X&&&&&X,,,,,X@@@@@X..&..X@@@XXX....&.@.&.@X*99*X%%X@@@X.&.&.X&&&&&X,,,,,X@@@@@X99.99X9XXX.X..@.&.@.&.@X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...X..@.&.@.&.@XX##XX%%+^...&.&.&+...@.@.@+...@@@@@+.....99+...+..@.&.@.&.8+^^^^X%%+^...&.&.&+...@.@.@+...@@@@@+.....99+...+..@.&.@.&.8+^^^^X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...X..@.&.@.&.@XX##XX%%X@@@X.&.&.X&&&&&X,,,,,X@@@@@X99.99X9XXX.X..@.&.@.&.@X****X%%X999X..9..X&&&&&X,,,,,X@@@@@X..&..X@@@XXX....&.@.&.@X*99*X%%X+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX+XXXXX....@.&.@X****X%%X.........................................XXX....&.@X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX....XXX....@X****X%%X,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,+XX....+XX...X****X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 60;
}
