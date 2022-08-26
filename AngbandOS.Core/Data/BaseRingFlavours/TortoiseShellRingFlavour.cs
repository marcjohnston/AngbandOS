using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TortoiseShellRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Tortoise Shell";
}
