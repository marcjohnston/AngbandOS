namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightBrownSplatProjectileGraphic : ProjectileGraphic
{
    private BrightBrownSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownSplat";
}
