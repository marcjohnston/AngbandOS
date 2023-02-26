namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyContractAnimation : Animation
{
    private GreyContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyContract";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"Oo·";
}
