namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyCloudAnimation : Animation
{
    private GreyCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyCloud";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"+*+*+*+";
}
