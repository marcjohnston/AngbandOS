using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PlanetXVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Planet X";
    public override int Category => 7;
    public override int Height => 13;
    public override int Rating => 10;
    public override string Text => "%%%%%%%%%%%%%%%%.............%%.XXXXX#XXXXX.%%.XXX,,,,,XXX.%%.X,XX,,,XX,X.%%.X,,XX9XX,,X.%%.#,,9###9,,#.%%.X,,XX9XX,,X.%%.X,XX,,,XX,X.%%.XXX,,,,,XXX.%%.XXXXX#XXXXX.%%.............%%%%%%%%%%%%%%%%";
    public override int Width => 15;
}
