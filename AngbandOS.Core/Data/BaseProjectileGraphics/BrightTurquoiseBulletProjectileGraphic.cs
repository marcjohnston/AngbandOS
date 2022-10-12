using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightTurquoiseBulletProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseBullet";
}
