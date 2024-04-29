// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemFactories;

[Serializable]
internal class OfTheMagiStaffItemFactory : StaffItemFactory
{
    private OfTheMagiStaffItemFactory(Game game) : base(game) { } // This object is a singleton.

    public override Symbol Symbol => Game.SingletonRepository.Get<Symbol>(nameof(UnderscoreSymbol));
    public override string Name => "the Magi";

    public override void ApplyMagic(Item item, int level, int power, Store? store)
    {
        item.TypeSpecificValue = Game.DieRoll(2) + 2;
    }
    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 4500;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "the Magi";
    public override int LevelNormallyFound => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (Game.TryRestoringAbilityScore(Ability.Intelligence))
        {
            eventArgs.Identified = true;
        }
        if (Game.Mana.IntValue < Game.MaxMana.IntValue)
        {
            Game.Mana.IntValue = Game.MaxMana.IntValue;
            Game.FractionalMana = 0;
            eventArgs.Identified = true;
            Game.MsgPrint("Your feel your head clear.");
        }
    }
    public override Item CreateItem() => new Item(Game, this);
}
