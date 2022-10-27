using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackBoltProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackBolt";
}
