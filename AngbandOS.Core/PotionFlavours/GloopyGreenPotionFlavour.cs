using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GloopyGreenPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Green;
    public override string Name => "Gloopy Green";
}
