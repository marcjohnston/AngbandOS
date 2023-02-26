namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrightGreyBoltProjectileGraphic : ProjectileGraphic
{
    private BrightGreyBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyBolt";
}
