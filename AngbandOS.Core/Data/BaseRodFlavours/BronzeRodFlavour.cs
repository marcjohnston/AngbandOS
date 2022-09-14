using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BronzeRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Bronze";
}
