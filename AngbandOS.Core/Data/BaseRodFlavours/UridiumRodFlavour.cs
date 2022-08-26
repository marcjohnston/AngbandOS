using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class UridiumRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Uridium";
}
