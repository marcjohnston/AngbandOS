// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class PerceptionStaffItemFactory : StaffItemFactory
{
    private PerceptionStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Perception";

    public override int StaffChargeCount => Game.DieRoll(15) + 5;
    public override int Cost => 400;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Perception";
    public override int LevelNormallyFound => 10;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (10, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (!Game.RunSuccessfulScript(nameof(IdentifyItemScript)))
        {
            eventArgs.ChargeUsed = false;
        }
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
