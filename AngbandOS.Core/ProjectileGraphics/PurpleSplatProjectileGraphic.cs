namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class PurpleSplatProjectileGraphic : ProjectileGraphic
{
    private PurpleSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleSplat";
}
