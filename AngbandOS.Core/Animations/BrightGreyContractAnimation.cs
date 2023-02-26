namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreyContractAnimation : Animation
{
    private BrightGreyContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyContract";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"Oo·";
}
