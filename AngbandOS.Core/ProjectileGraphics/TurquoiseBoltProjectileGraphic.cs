using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseBolt";
}
