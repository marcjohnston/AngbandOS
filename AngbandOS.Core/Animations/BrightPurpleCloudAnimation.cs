namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPurpleCloudAnimation : Animation
{
    private BrightPurpleCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleCloud";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"+*+*+*+";
}
