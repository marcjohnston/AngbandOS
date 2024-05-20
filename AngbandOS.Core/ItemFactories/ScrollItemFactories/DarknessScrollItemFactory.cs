// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DarknessScrollItemFactory : ScrollItemFactory
{
    private DarknessScrollItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(QuestionMarkSymbol);
    public override string Name => "Darkness";

    public override string FriendlyName => "Darkness";
    public override int LevelNormallyFound => 1;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (1, 1)
    };
    public override int Weight => 5;

    public override void Read(ReadScrollEvent eventArgs)
    {
        if (!Game.HasBlindnessResistance && !Game.HasDarkResistance)
        {
            Game.BlindnessTimer.AddTimer(3 + Game.DieRoll(5));
        }
        if (Game.UnlightArea(10, 3))
        {
            eventArgs.Identified = true;
        }
    }
}
