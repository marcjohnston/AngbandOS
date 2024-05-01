// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class SlowMonstersStaffItemFactory : StaffItemFactory
{
    private SlowMonstersStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(UnderscoreSymbol));
    public override string Name => "Slow Monsters";

    public override int StaffChargeCount => Game.DieRoll(5) + 6;

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 800;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "Slow Monsters";
    public override int LevelNormallyFound => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int Weight => 50;
    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.RunSuccessfulScript(nameof(SlowMonstersScript)))
        {
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
