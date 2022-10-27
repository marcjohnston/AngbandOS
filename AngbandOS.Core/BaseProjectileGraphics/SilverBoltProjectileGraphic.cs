using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverBolt";
}
