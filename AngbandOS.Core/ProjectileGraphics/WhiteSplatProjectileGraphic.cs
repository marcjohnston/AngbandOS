namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class WhiteSplatProjectileGraphic : ProjectileGraphic
{
    private WhiteSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteSplat";
}
