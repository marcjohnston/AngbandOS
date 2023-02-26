namespace AngbandOS.Core.Animations;

[Serializable]
internal class CopperContractAnimation : Animation
{
    private CopperContractAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperContract";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"Oo·";
}
