using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrownBulletProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '·';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownBullet";
}
