using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrassRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}
