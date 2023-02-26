namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPinkCloudAnimation : Animation
{
    private BrightPinkCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkCloud";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"+*+*+*+";
}
