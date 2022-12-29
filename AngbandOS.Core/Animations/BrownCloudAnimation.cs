namespace AngbandOS.Core;

[Serializable]
internal class BrownCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownCloud";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"+*+*+*+";
}
