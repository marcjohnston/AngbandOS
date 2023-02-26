namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightTurquoiseContractAnimation : Animation
{
    private BrightTurquoiseContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseContract";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"Oo·";
}
