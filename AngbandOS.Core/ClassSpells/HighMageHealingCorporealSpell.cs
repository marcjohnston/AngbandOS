internal class HighMageHealingCorporealSpell : ClassSpell
{
    private HighMageHealingCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealing);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 15;
}