namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrownSplatProjectileGraphic : ProjectileGraphic
{
    private BrownSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownSplat";
}
