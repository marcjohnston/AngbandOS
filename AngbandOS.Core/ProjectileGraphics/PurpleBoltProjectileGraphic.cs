namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PurpleBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleBolt";
}
