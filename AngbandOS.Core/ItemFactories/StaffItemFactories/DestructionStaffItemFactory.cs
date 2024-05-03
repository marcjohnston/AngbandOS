// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class DestructionStaffItemFactory : StaffItemFactory
{
    private DestructionStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    protected override string SymbolName => nameof(UnderscoreSymbol);
    public override string Name => "*Destruction*";

    public override int StaffChargeCount => Game.DieRoll(3) + 1;

    public override int Cost => 2500;
    public override int DamageDice => 1;
    public override int DamageSides => 2;
    public override string FriendlyName => "*Destruction*";
    public override int LevelNormallyFound => 50;
    public override (int level, int chance)[]? DepthsFoundAndChances => new (int, int)[]
    {
        (50, 1),
        (70, 1)
    };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        Game.DestroyArea(Game.MapY.IntValue, Game.MapX.IntValue, 15);
        eventArgs.Identified = true;
    }
    public override Item CreateItem() => new Item(Game, this);
}
