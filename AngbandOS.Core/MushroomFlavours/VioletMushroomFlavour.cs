using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class VioletMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "Violet";
}
