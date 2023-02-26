namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightOrangeSplatProjectileGraphic : ProjectileGraphic
{
    private BrightOrangeSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeSplat";
}
