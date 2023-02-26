namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseExpandAnimation : Animation
{
    private ChartreuseExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseExpand";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"·oO";
}
