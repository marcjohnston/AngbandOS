using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreenBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenBolt";
}
