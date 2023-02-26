namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GreySplatProjectileGraphic : ProjectileGraphic
{
    private GreySplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySplat";
}
