namespace AngbandOS.Core.Animations;

[Serializable]
internal class TurquoiseControlAnimation : Animation
{
    private TurquoiseControlAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseControl";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"!!!!";
}
