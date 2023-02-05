namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreyBoltProjectileGraphic : ProjectileGraphic
{
    public override char Character => '|';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyBolt";
}
