namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenContractAnimation : Animation
{
    private GreenContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenContract";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"Oo·";
}
