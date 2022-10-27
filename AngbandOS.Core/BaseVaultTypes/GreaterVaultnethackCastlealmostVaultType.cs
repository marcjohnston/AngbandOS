using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaultnethackCastlealmostVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Greater vault (nethack castle (almost))";
    public override int Category => 8;
    public override int Height => 19;
    public override int Rating => 35;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%............................................................%%.XXXXXXX............................................XXXXXXX.%%.X,,9,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,9,,X.%%.X,,,,,+.......^....*....^ ..........^.......*...^..+,,,,,X.%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+XXXXXXXXXXXXXXXXXXXXXXXXXXX.%%......X,.,9,,,,X,,,,,,,,,+,.,.,.,.,.,X,.,.,.+^+,.,.,.X......%%......X,.9*9,.,X,,,,,,,,,X,.,..,..,.,X,.,.,.X^X,.,.,.X......%%....&.X.&*@*&,.XXXXXXXXXXX,.,.,9,.,.,XXXXXXXX+XXXXXXXX......%%......+9*@8@*9.+^^^^^^^^^+,.,,9@9,,.,+^^^^^^^^^^^^^^^+......%%....&.X.&*@*&,.XXXXXXXXXXX,.,.,9,.,.,XXXXXXXX+XXXXXXXX......%%......X,.9*9,.,X,,,,,,,,,X,.,.,,,.,.,X.,.,.,X^X.,.,.,X......%%......X,.,9,,,,X,,,,,,,,,+,.,.,.,.,.,X.,.,.,+^+.,.,.,X......%%.XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX+XXXXXXXXXXXXXXXXXXXXXXXXXXX.%%.X,,,,,+.......^....*....^...........^.......*...^..+,,,,,X.%%.X,,9,,XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX,,9,,X.%%.XXXXXXX............................................XXXXXXX.%%............................................................%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 62;
}
