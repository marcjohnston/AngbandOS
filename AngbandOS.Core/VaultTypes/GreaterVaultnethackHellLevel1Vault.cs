using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultnethackHellLevel1Vault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (nethack hell level #1)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.....................................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.XX*XXXXXXXXXX**XXXXXXXXXXXX***********************X.%%.XX*X,,,,X***X+XX,,,,,,X***XXXXXXXXXXXX^^^^^^^^^^^^X.%%.XX,X,,,,+***X@^+,,,,,,X***+,,,,,,,,,,X^^^^^^^^^^^^X.%%.XX&X,,,,XXXXXXXX^^^^^^^^^^X,,,XXXXXXXXXXXXXX^^^^^^X.%%.XX+X....XXXX.............^X,,,+,,,,,,,,,,,9XXXXX^^X.%%.+^^^^^^^^^^+^^^^^^^^^^^^^^XXXXX,,,,,,,,,,,9+888+@@X.%%.XX+X....XXXX.............^X,,,+,,,,,,,,,,,9XXXXX^^X.%%.XX&X,,,,XXXXXXXX^^^^^^^^^^X,,,XXXXXXXXXXXXXX^^^^^^X.%%.XX,X,,,,+***X@^+,,,,,,X***+,,,,,,,,,,X^^^^^^^^^^^^X.%%.XX*X,,,,X***X+XX,,,,,,X***XXXXXXXXXXXX^^^^^^^^^^^^X.%%.XX*XXXXXXXXXX**XXXXXXXXXXXX***********************X.%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 55;
}
