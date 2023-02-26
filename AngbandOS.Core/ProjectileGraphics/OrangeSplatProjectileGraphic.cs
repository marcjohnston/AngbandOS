namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class OrangeSplatProjectileGraphic : ProjectileGraphic
{
    private OrangeSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSplat";
}
