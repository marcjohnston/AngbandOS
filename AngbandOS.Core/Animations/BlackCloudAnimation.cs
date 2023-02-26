namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackCloudAnimation : Animation
{
    private BlackCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackCloud";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"+*+*+*+";
}
