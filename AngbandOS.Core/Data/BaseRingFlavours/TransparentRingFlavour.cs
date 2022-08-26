using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TransparentRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Transparent";
}
