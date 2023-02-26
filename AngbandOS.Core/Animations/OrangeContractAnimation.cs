namespace AngbandOS.Core.Animations;

[Serializable]
internal class OrangeContractAnimation : Animation
{
    private OrangeContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeContract";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"Oo·";
}
