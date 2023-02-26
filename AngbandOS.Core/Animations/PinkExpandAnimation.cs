namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkExpandAnimation : Animation
{
    private PinkExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkExpand";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"·oO";
}
