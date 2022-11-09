using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultnethackHellLevel2Vault : Vault
{
    public override char Character => '#';
    public override string Name => "Greater vault (nethack hell level #2)";
    public override int Category => 8;
    public override int Height => 15;
    public override int Rating => 30;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%....................................................%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...%%.+^XX,+^^^^^X^^^^^^^^^^^^^^^^^^^^^X,,,X,@^X*^*+9X...%%.X^XX,X^XXX,X@XXXXXXXXXXXXXXXXXXX^X,X,X,X^X*X*X9X...%%.X^XX,X^^^X,X^^^^^^^^^^^^^^^^^^@X^X,X,X,X^X*X*X9X...%%.X^XXXXXX^X,XXXXXXXXXXXXXXXXXXX^X^X,X,X,X^X*X*X+XXX.%%.X^^^^^^X^X,X,,,,,,,,,,,,,,,,,X^X^X,X,X,X^X*X*X888X.%%.X+XXXX^X^X,X,XXXXXXXXXXXXXXX,X^X^X,X,X,X^X*X*X+XXX.%%.X,XX,X^X^X,X,X,,,,,,,,,,,,,,,X^X^X,X,X,X^X*X*X9X...%%.X,XX,X^X&X,X,X,XXXXXXXXXXXXXXX^X^X,X,X,X^X*X*X9X...%%.X,XX,+^^^X,,,X^^^^^^^^^^^^^^^^^X^@,X,,,X^@*X*+9X...%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX...%%....................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 54;
}
