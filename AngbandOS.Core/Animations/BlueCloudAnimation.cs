namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueCloudAnimation : Animation
{
    private BlueCloudAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueCloud";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"+*+*+*+";
}
