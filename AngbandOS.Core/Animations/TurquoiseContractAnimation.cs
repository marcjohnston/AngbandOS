namespace AngbandOS.Core.Animations;

[Serializable]
internal class TurquoiseContractAnimation : Animation
{
    private TurquoiseContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseContract";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"Oo·";
}
