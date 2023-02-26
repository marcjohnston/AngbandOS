namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBeigeSplatProjectileGraphic : ProjectileGraphic
{
    private BrightBeigeSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeSplat";
}
