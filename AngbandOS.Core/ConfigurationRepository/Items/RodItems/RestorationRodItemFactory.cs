// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class RestorationRodItemFactory : RodItemFactory
{
    private RestorationRodItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override bool RequiresAiming => false;
    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get(nameof(MinusSignSymbol));
    public override string Name => "Restoration";

    public override int[] Chance => new int[] { 16, 0, 0, 0 };
    public override int Cost => 25000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "Restoration";
    public override int Level => 80;
    public override int[] Locale => new int[] { 80, 0, 0, 0 };
    public override int Weight => 15;
    public override void Execute(ZapRodEvent zapRodEvent)
    {
        if (SaveGame.RunSuccessfulScript(nameof(RestoreLevelScript)))
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TryRestoringAbilityScore(Ability.Strength))
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TryRestoringAbilityScore(Ability.Intelligence))
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TryRestoringAbilityScore(Ability.Wisdom))
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TryRestoringAbilityScore(Ability.Dexterity))
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TryRestoringAbilityScore(Ability.Constitution))
        {
            zapRodEvent.Identified = true;
        }
        if (SaveGame.TryRestoringAbilityScore(Ability.Charisma))
        {
            zapRodEvent.Identified = true;
        }
        zapRodEvent.Item.TypeSpecificValue = 999;
    }
    public override Item CreateItem() => new RestorationRodItem(SaveGame);
}
