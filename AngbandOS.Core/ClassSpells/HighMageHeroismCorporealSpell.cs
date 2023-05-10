internal class HighMageHeroismCorporealSpell : ClassSpell
{
    private HighMageHeroismCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHeroism);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 20;
}