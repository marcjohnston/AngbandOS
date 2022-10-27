using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreaterVaulthugeVaultType : BaseVaultType
{
    public override char Character => '#';
    public override string Name => "Greater vault (huge)";
    public override int Category => 8;
    public override int Height => 17;
    public override int Rating => 45;
    public override string Text => "%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%+&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#&#8#&#8#&#88888888888#8#&#8#&#8#&X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8X%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX#X%%X8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&X%%X#XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%X&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#8#&#&+%%XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%";
    public override int Width => 39;
}
