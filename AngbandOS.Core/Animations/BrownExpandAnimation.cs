namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownExpandAnimation : Animation
{
    private BrownExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownExpand";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"·oO";
}
