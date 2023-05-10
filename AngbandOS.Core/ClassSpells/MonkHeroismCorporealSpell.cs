internal class MonkHeroismCorporealSpell : ClassSpell
{
    private MonkHeroismCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHeroism);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 20;
}