using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class EmeraldAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Emerald";
}
