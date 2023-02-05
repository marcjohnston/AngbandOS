namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class RedBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedBolt";
}
