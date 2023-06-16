namespace AngbandOS.Core.ItemCategories;

[Serializable]
internal class BeginnersHandbookSorceryBookItemFactory : SorceryBookItemFactory
{
    private BeginnersHandbookSorceryBookItemFactory(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.

    public override char Character => '?';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "[Beginner's Handbook]";

    public override int[] Chance => new int[] { 1, 0, 0, 0 };
    public override int Cost => 100;
    public override int Dd => 1;
    public override int Ds => 1;
    public override string FriendlyName => "[Beginner's Handbook]";
    public override int Level => 10;
    public override int[] Locale => new int[] { 10, 0, 0, 0 };
    public override int? SubCategory => 0;
    public override int Weight => 30;
    public override bool KindIsGood => false;
    public override Item CreateItem() => new BeginnersHandbookSorceryBookItem(SaveGame);

    public override Spell[] Spells => new Spell[]
    {
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellDetectMonsters>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellPhaseDoor>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellDetectDoorsAndTraps>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellLightArea>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellConfuseMonster>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellTeleport>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellSleepMonster>(),
        SaveGame.SingletonRepository.Spells.Get<SorcerySpellRecharging>()
    };
}
