namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBlueContractAnimation : Animation
{
    private BrightBlueContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueContract";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"Oo·";
}
