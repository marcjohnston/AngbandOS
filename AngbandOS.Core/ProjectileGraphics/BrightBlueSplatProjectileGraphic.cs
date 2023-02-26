namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBlueSplatProjectileGraphic : ProjectileGraphic
{
    private BrightBlueSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueSplat";
}
