namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class CeleanoFragmentsTarotBookItemFactory : TarotBookItemFactory
{
    private CeleanoFragmentsTarotBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.Pink;
    public override string Name => "[Celeano Fragments]";

    public override int[] Chance => new int[] { 3, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Celeano Fragments]";
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override int Level => 90;
    public override int[] Locale => new int[] { 90, 0, 0, 0 };
    public override int? SubCategory => 3;

    /// <summary>
    /// Returns true, because this book is a high level book.
    /// </summary>
    public override bool IsHighLevelBook => true;
    public override int Weight => 30;
    public override bool KindIsGood => true;
    public override Item CreateItem() => new CeleanoFragmentsTarotBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<TarotSpellEtherealDivination>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellAstralLore>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonUndead>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonDragon>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellMassSummons>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonDemon>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonAncientDragon>(),
        SaveGame.SingletonRepository.Spells.Get<TarotSpellSummonGreaterUndead>()
    };
}
