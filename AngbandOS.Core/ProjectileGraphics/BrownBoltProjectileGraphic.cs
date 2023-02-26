namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class BrownBoltProjectileGraphic : ProjectileGraphic
{
    private BrownBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownBolt";
}
