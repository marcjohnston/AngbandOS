namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class YellowBoltProjectileGraphic : ProjectileGraphic
{
    private YellowBoltProjectileGraphic(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '|';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowBolt";
}
