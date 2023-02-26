namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeExpandAnimation : Animation
{
    private BeigeExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeExpand";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"·oO";
}
