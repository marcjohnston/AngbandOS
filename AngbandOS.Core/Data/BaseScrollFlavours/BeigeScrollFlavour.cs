using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BeigeScrollFlavour : BaseScrollFlavour
{
    public override char Character => '?';
    public override Colour Colour => Colour.Beige;
}
