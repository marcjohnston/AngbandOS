namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleFlashAnimation : Animation
{
    private PurpleFlashAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleFlash";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"********";
}
