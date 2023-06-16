namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class YogicMasteryCorporealBookItemFactory : CorporealBookItemFactory
{
    private YogicMasteryCorporealBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "[Yogic Mastery]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 1000;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Yogic Mastery]";
    public override int Level => 20;
    public override int[] Locale => new int[] { 20, 0, 0, 0 };
    public override int? SubCategory => 1;
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new YogicMasteryCorporealBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellBurnResistance>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellDetoxify>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellCureCriticalWounds>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellSeeInvisible>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellTeleport>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellHaste>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellHealing>(),
        SaveGame.SingletonRepository.Spells.Get<CorporealSpellResistTrue>()
    };
}
