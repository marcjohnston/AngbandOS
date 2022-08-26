using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBeigeScrollFlavour : BaseScrollFlavour
{
    public override char Character => '?';
    public override Colour Colour => Colour.BrightBeige;
}
