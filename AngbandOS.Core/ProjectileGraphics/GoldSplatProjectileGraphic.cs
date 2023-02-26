namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GoldSplatProjectileGraphic : ProjectileGraphic
{
    private GoldSplatProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldSplat";
}
