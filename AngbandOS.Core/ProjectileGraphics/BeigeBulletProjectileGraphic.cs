using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BeigeBulletProjectileGraphic : ProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeBullet";
}
