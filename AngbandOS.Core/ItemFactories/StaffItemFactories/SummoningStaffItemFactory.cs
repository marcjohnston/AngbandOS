// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SummoningStaffItemFactory : StaffItemFactory
{
    private SummoningStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Summoning";

    public override int StaffChargeCount => Game.DieRoll(3) + 1;

    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string CodedName => "Summoning";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1),
        (50, 1)
    };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        for (int k = 0; k < Game.DieRoll(4); k++)
        {
            if (Game.SummonSpecific(Game.MapY.IntValue, Game.MapX.IntValue, Game.Difficulty, null))
            {
                eventArgs.Identified = true;
            }
        }
    }
}
