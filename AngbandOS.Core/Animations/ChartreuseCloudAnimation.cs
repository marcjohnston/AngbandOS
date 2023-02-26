namespace AngbandOS.Core.Animations;

[Serializable]
internal class ChartreuseCloudAnimation : Animation
{
    private ChartreuseCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseCloud";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"+*+*+*+";
}
