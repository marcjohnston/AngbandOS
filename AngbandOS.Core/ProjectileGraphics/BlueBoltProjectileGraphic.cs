namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BlueBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueBolt";
}
