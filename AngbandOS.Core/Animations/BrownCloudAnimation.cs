namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownCloudAnimation : Animation
{
    private BrownCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownCloud";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"+*+*+*+";
}
