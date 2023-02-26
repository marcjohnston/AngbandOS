namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreySplatProjectileGraphic : ProjectileGraphic
{
    private BrightGreySplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreySplat";
}
