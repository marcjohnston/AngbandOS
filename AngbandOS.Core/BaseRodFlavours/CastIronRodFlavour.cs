using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CastIronRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Cast Iron";
}
