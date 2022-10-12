using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBlueBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueBolt";
}
