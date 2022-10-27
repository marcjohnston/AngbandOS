using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultgreaterCastleVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Greater vault (greater castle)";
    public override int Category => 8;
    public override int Height => 25;
    public override int Rating => 40;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.................................................%%...XXXXXX...............................XXXXXX...%%..XX,,,,XX.............................XX,,,,XX..%%.XX,*99*,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,*99*,XX.%%.XX,*99*,+^^^^^^^^^^^^^^^^^^^^^^^^^^^^^+,*99*,XX.%%..XX,,,,XXXXXXXXXXXXXXX+X+XXXXXXXXXXXXXXX,,,,XX..%%...XX++XX...............X...............XX++XX...%%....X^^X.............XXXXXXX.............X^^X....%%....X^^X.X^^^^^^^^^^^^^^^^^^^^^^^^^^^^^X.X^^X....%%....X^^X.X^^^XXXXXXXXXXXXXXXXXXXXXXX^^^X.X^^X....%%....X^^+&X^^XX@.+***************+.@XX^^X&+^^X....%%....X^^XXX^^+@.@X*9999988899999*X@.@+^^XXX^^X....%%....X^^+.X^^XX@.+***************+.@XX^^X.+^^X....%%....X^^X.X^^^XXXXXXXXXXXXXXXXXXXXXXX^^^X.X^^X....%%....X^^X.X^^^^^^^^^^^^^^^^^^^^^^^^^^^^^X.X^^X....%%....X^^X............XXXX+XXXX............X^^X....%%...XX++XX..........XX&.&.&.&XX..........XX++XX...%%..XX,,,,XXXXXXXXXXXX&.&.&.&.&XXXXXXXXXXXX,,,,XX..%%.XX,*99*,+********9XXXXX+XXXXX9********+,*99*,XX.%%.XX,*99*,XXXXXXXXXXX&.&.&.&.&XXXXXXXXXXX,*99*,XX.%%..XX,,,,XX.........XX&.&.&.&XX.........XX,,,,XX..%%...XXXXXX...........XXXX+XXXX...........XXXXXX...%%.................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 51;
}
