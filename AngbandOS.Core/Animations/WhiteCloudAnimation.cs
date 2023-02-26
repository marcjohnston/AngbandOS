namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteCloudAnimation : Animation
{
    private WhiteCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override string Name => "WhiteCloud";
    public override string Sequence => @"+*+*+*+";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}
