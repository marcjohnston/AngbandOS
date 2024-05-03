// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class TreasureLocationStaffItemFactory : StaffItemFactory
{
    private TreasureLocationStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "Treasure Location";

    public override int StaffChargeCount => Game.DieRoll(20) + 8;

    public override int Cost => 200;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Treasure Location";
    public override int LevelNormallyFound => 5;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (5, 1)
    };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.DetectTreasure())
        {
            eventArgs.Identified = true;
        }
        if (Game.DetectObjectsGold())
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
