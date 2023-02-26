namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedExpandAnimation : Animation
{
    private RedExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedExpand";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"·oO";
}
