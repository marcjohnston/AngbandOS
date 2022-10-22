using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedBolt";
}
