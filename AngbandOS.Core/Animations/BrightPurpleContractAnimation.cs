namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPurpleContractAnimation : Animation
{
    private BrightPurpleContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleContract";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"Oo·";
}
