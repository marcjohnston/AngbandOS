// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SaltWaterPotionItemFactory : PotionItemFactory
{
    private SaltWaterPotionItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(ExclamationPointSymbol);
    public override string Name => "Salt Water";

    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (0, 1)
    };
    public override int DamageDice => 1;
    public override int DamageSides => 1;
    public override string CodedName => "Salt Water";
    public override int Weight => 4;

    public override bool Quaff()
    {
        // Salt water makes you vomit, but gets rid of poison
        Game.MsgPrint("The saltiness makes you vomit!");
        Game.SetFood(Constants.PyFoodStarve - 1);
        Game.PoisonTimer.ResetTimer();
        Game.ParalysisTimer.AddTimer(4);
        return true;
    }

    public override bool Smash(int who, int y, int x)
    {
        return true;
    }
}
