namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class RedSplatProjectileGraphic : ProjectileGraphic
{
    private RedSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSplat";
}
