// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class SpecialEnlightenmentPotionItemFactory : PotionItemFactory
{
    private SpecialEnlightenmentPotionItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override Symbol Symbol => SaveGame.SingletonRepository.Symbols.Get<ExclamationPointSymbol>();
    public override string Name => "*Enlightenment*";

    public override int[] Chance => new int[] { 4, 0, 0, 0 };
    public override int Cost => 80000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "*Enlightenment*";
    public override int Level => 70;
    public override int[] Locale => new int[] { 70, 0, 0, 0 };
    public override int Weight => 4;
    public override bool Quaff()
    {
        // *Enlightenment* shows you the whole level, increases your intelligence and
        // wisdom, identifies all your items, and detects everything
        SaveGame.MsgPrint("You begin to feel more enlightened...");
        SaveGame.MsgPrint(null);
        SaveGame.WizLight();
        SaveGame.TryIncreasingAbilityScore(Ability.Intelligence);
        SaveGame.TryIncreasingAbilityScore(Ability.Wisdom);
        SaveGame.DetectTraps();
        SaveGame.DetectDoors();
        SaveGame.DetectStairs();
        SaveGame.DetectTreasure();
        SaveGame.DetectObjectsGold();
        SaveGame.DetectObjectsNormal();
        SaveGame.IdentifyPack();
        SaveGame.SelfKnowledge();
        return true;
    }
    public override Item CreateItem() => new SpecialEnlightenmentPotionItem(SaveGame);
}