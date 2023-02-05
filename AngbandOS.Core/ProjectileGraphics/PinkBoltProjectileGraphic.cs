namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PinkBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkBolt";
}
