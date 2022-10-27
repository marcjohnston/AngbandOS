using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperBolt";
}
