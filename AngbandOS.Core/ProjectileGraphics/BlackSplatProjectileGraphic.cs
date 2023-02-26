namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BlackSplatProjectileGraphic : ProjectileGraphic
{
    private BlackSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackSplat";
}
