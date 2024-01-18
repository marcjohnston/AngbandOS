// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class StaffOfTheMagi : StaffItemClass
{
    private StaffOfTheMagi(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(UnderscoreSymbol));
    public override string Name => "the Magi";

    public override int[] Chance => new int[] { 2, 0, 0, 0 };
    public override int Cost => 4500;
    public override int Dd => 1;
    public override int Ds => 2;
    public override string FriendlyName => "the Magi";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 50;

    public override void UseStaff(UseStaffEvent eventArgs)
    {
        if (SaveGame.TryRestoringAbilityScore(Ability.Intelligence))
        {
            eventArgs.Identified = true;
        }
        if (SaveGame.Mana < SaveGame.MaxMana)
        {
            SaveGame.Mana = SaveGame.MaxMana;
            SaveGame.FractionalMana = 0;
            eventArgs.Identified = true;
            SaveGame.MsgPrint("Your feel your head clear.");
            SaveGame.SingletonRepository.FlaggedActions.Get(nameof(RedrawManaFlaggedAction)).Set();
        }
    }
    public override Item CreateItem() => new OfTheMagiStaffItem(SaveGame);
}
