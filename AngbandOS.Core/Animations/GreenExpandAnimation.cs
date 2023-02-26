namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenExpandAnimation : Animation
{
    private GreenExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenExpand";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"·oO";
}
