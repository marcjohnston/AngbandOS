namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class SilverSplatProjectileGraphic : ProjectileGraphic
{
    private SilverSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverSplat";
}
