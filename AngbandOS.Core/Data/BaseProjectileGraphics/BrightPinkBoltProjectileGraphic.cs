using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPinkBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkBolt";
}
