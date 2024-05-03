// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class LightStaffItemFactory : StaffItemFactory
{
    private LightStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Light";

    public override int StaffChargeCount => Game.DieRoll(20) + 8;
    public override int Cost => 250;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string FriendlyName => "Light";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.LightArea(Game.DiceRoll(2, 8), 2))
        {
            eventArgs.Identified = true;
        }
    }
}
