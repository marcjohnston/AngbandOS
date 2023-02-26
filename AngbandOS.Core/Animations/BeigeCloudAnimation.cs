namespace AngbandOS.Core.Animations;

[Serializable]
internal class BeigeCloudAnimation : Animation
{
    private BeigeCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeCloud";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"+*+*+*+";
}
