// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CardMasteryTarotBookItemFactory : TarotBookItemFactory
{
    private CardMasteryTarotBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "[Card Mastery]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Card Mastery]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int? SubCategory => 1;
    public override int Weight => 30;
    public override bool KindIsGood => false;

    public override Item CreateItem() => new CardMasteryTarotBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonObject>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonAnimal>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellPhantasmalServant>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonMonster>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellConjureElemental>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellTeleportLevel>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellWordOfRecall>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellBanish>()
    };
}
