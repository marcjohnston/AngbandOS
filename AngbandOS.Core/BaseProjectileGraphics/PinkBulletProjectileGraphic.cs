using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkBulletProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkBullet";
}
