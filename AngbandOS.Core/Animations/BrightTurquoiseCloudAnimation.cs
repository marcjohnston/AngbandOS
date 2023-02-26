namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightTurquoiseCloudAnimation : Animation
{
    private BrightTurquoiseCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseCloud";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"+*+*+*+";
}
