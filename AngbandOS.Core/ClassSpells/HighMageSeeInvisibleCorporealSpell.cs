internal class HighMageSeeInvisibleCorporealSpell : ClassSpell
{
    private HighMageSeeInvisibleCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeInvisible);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 5;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 6;
}