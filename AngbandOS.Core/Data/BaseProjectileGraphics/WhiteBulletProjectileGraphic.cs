using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteBulletProjectileGraphic : BaseProjectileGraphic
{
    public override char Character => '·';
    public override string Name => "WhiteBullet";
}
