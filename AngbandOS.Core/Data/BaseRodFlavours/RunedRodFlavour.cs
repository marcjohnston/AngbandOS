using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RunedRodFlavour : BaseRodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Red;
    public override string Name => "Runed";
}
