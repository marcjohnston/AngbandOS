namespace AngbandOS.Core.Animations;

[Serializable]
internal class CopperExpandAnimation : Animation
{
    private CopperExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperExpand";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"·oO";
}
