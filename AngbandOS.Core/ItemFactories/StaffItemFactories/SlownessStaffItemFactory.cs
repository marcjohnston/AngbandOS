// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlownessStaffItemFactory : StaffItemFactory
{
    private SlownessStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    /// <summary>
    /// Returns true because this is a broken item. 
    /// </summary>
    public override bool InitialBrokenStomp => true;
    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Slowness";

    public override int StaffChargeCount => Game.DieRoll(8) + 8;

    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string CodedName => "Slowness";
    public override int LevelNormallyFound => 40;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (40, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.SlowTimer.AddTimer(Game.DieRoll(30) + 15))
        {
            eventArgs.Identified = true;
        }
    }
}
