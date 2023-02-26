namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackExpandAnimation : Animation
{
    private BlackExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackExpand";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"·oO";
}
