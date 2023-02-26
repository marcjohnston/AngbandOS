namespace AngbandOS.Core.Animations;

[Serializable]
internal class TurquoiseCloudAnimation : Animation
{
    private TurquoiseCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseCloud";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"+*+*+*+";
}
