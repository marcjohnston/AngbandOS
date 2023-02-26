namespace AngbandOS.Core.Animations;

[Serializable]
internal class SilverCloudAnimation : Animation
{
    private SilverCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverCloud";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"+*+*+*+";
}
