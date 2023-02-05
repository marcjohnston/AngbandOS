namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightRedBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedBolt";
}
