namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedContractAnimation : Animation
{
    private RedContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedContract";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"Oo·";
}
