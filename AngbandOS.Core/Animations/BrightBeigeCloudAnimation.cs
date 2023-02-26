namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBeigeCloudAnimation : Animation
{
    private BrightBeigeCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeCloud";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"+*+*+*+";
}
