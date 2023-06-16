namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class PonapeScriptureLifeBookItemFactory : LifeBookItemFactory
{
    private PonapeScriptureLifeBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "[Ponape Scripture]";

    public override int[] Chance => new int[] { 3, 0, 0, 0 };
    public override int Cost => 100000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Ponape Scripture]";
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
    public override Item CreateItem() => new PonapeScriptureLifeBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<LifeSpellHeroism>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellPrayer>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellBlessWeapon>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellRestoration>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellHealingTrue>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellHolyVision>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellDivineIntervention>(),
        SaveGame.SingletonRepository.Spells.Get<LifeSpellHolyInvulnerability>()
    };
}
