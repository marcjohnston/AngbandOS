using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultnethackSamuraiCastleVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Greater vault (nethack samurai castle)";
    public override int Category => 8;
    public override int Height => 20;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.........................................................%%.XXXXX.............................................XXXXX.%%.X***X.............................................X***X.%%.X***XXX.....XX+XXXXXXXXXXXXXXXXXXXXXXXXX+XX.....XXX***X.%%.XXX@,,X.....X^&^X,,,X***X,,,X***X^^^+8X^&^X.....X,,@XXX.%%...X,,,XXXXXXX^^^X,,,X^^^X,,,X^^^X@@^X8X^^^XXXXXXX,,,X...%%...XXX^^^^^^^^^XXXXX+XXX+X+XXXXX+X+XXXXXXX^^^^^^^^^XXX...%%.....X^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^X.....%%.....X^^+,,,,,,,,+,,,,,,,,,99,,,,,,,,,,+,,,,,,,,+^^X.....%%.....X^^+,,,,,,,,+,,,,,,,,,99,,,,,,,,,,+,,,,,,,,+^^X.....%%.....X^^XXXXXXXX*X,,,,,,,,,,,,,,,,,,,,,X*XXXXXXXX^^X.....%%...XXX^^^^^^^^^XXXXXXX+X+XXXXX+X+XXX+XXXXX^^^^^^^^^XXX...%%...X,,,XXXXXXX^^^X8X^@@X^^^X^^^X,,,X,,,X^^^XXXXXXX,,,X...%%.XXX@,,X.....X^&^X8+^^^X***X***X,,,X,,,X^&^X.....X,,@XXX.%%.X***XXX.....XX+XXXXXXXXXXXXXXXXXXXXXXXXX+XX.....XXX***X.%%.X***X.............................................X***X.%%.XXXXX.............................................XXXXX.%%.........................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 59;
}
