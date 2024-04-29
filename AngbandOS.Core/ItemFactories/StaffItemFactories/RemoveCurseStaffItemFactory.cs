// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class RemoveCurseStaffItemFactory : StaffItemFactory
{
    private RemoveCurseStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(UnderscoreSymbol));
    public override string Name => "Remove Curse";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 500;
    public override int Dd => 1;
    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(3) + 4;
    }
    public override int Ds => 2;
    public override string FriendlyName => "Remove Curse";
    public override int LevelNormallyFound => 40;
    public override int[] Locale => new int[] { 40, 0, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.RunSuccessfulScript(nameof(RemoveCurseScript)))
        {
            if (Game.BlindnessTimer.Value == 0)
            {
                Game.MsgPrint("The staff glows blue for a moment...");
            }
            eventArgs.Identified = true;
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
