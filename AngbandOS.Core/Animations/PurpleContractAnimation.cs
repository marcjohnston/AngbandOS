namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleContractAnimation : Animation
{
    private PurpleContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleContract";
    public override Colour AlternateColour => Colour.Purple;
    public override string Sequence => @"Oo·";
}
