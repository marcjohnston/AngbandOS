using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultkomOmboVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Greater vault (kom ombo)";
    public override int Category => 8;
    public override int Height => 36;
    public override int Rating => 40;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%.XXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X****X,99,X9889X,99,X****X.%%.X****X,,,,X9999X,,,,X****X.%%.X+XXXX+XXXX+XXXX+XXXX+XXXX.%%.X@^^^^^^^^^^^^^^^^^^^^^^@X.%%.X^XXXXXXXXXXXXXXXXXXXXXX^X.%%.X^X**X,,X,,X,,X,,X,,X**X^X.%%.X^X,,X+XX+XX+XXX+XX+X,,X^X.%%.X^X,^+^^^^^^^^^^^^^^+^,X^X.%%.X^XXXX^XX+XX^^XX+XX^XXXX^X.%%.X^X,,X^X,,,X^^X,,,X^+^,X^X.%%.X^X,,X^X***X^^X***X^X,*X^X.%%.X^X,,X^X9X9X^^X9X9X^XXXX^X.%%.X^X,,X^X***X^^X***X^+^,X^X.%%.X^X++X^X,,,X^^X,,,X^X,*X^X.%%.X^X^^X^XX+XX^^XX+XX^XXXX^X.%%.X^X^^+^^^^^^^^^^^^^^X,*X^X.%%.X^X,,X^^^^^^^^^^^^^^+^,X^X.%%.X^XXXXXXX+XXXXXX+XXXXXXX^X.%%.X^X,X,X,,,,,XX,,,,,X***X^X.%%.X^X,X^X,***,++,***,+*@*X^X.%%.X^X,+^+,,,,,XX,,,,,X***X^X.%%.X^XXX+XXX+XXXXXX+XXXX+XX^X.%%.X^X*,^X,,,,,XX,,,,,+^^*X^X.%%.X^X,,^+,,*,,++,,*,,XX+XX^X.%%.X^X*,*X,,,,,XX,,,,,X,,,X^X.%%.X^XXXXXXX+XXXXXX+XXXXXXX^X.%%.X^X^^^^^^^^^^^^^^^^^^^^X^X.%%.X^X^^XX,XX^^XX^^XX,XX^^X^X.%%.X^X^^^^^^^^^^^^^^^^^^^^X^X.%%.X^+^^XX,XX^^XX^^XX,XX^^+^X.%%.X,X^^^^^^^^^^^^^^^^^^^^X,X.%%.XXXXXXXXX+XXXXXX+XXXXXXXXX.%%............................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 30;
}
