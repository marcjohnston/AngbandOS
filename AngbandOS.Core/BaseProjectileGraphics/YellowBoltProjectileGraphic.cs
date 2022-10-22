using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowBolt";
}
