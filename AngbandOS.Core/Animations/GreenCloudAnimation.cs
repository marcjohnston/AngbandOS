namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenCloudAnimation : Animation
{
    private GreenCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenCloud";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"+*+*+*+";
}
