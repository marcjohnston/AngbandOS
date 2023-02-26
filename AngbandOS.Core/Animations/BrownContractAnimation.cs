namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownContractAnimation : Animation
{
    private BrownContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownContract";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"Oo·";
}
