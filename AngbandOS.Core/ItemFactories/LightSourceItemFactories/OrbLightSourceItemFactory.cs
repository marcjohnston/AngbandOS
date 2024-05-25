// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OrbLightSourceItemFactory : LightSourceItemFactory
{
    private OrbLightSourceItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because orbs of light should be stomped automatically. 
    /// </summary>
    public override bool InitialBrokenStomp => true;

    protected override string SymbolName => nameof(TildeSymbol);
    public override ColorEnum Color => ColorEnum.BrightYellow;
    public override string Name => "Orb";

    /// <summary>
    /// Returns an intensity of light provided by the orb.  A value of 2 is returned, plus an additional 3
    /// if the orb is an artifact.
    /// </summary>
    /// <param name="oPtr"></param>
    /// <returns></returns>
    public override int CalculateTorch(Item item)
    {
        return base.CalculateTorch(item) + 2;
    }

    public override bool IdentityCanBeSensed => true;
    public override int Cost => 1000;
    public override int DamageDice => 1;

    public override int DamageSides => 1;
    protected override string? DescriptionSyntax  => "& Orb~";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 50;

    /// <summary>
    /// Returns false, because the player shouldn't be asked to stomp all Orbs of light. 
    /// </summary>
    public override bool AskDestroyAll => false;

    public override bool HasQualityRatings => true;
}
