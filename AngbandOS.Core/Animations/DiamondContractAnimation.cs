namespace AngbandOS.Core.Animations;

[Serializable]
internal class DiamondContractAnimation : Animation
{
    private DiamondContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondContract";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"Oo·";
}
