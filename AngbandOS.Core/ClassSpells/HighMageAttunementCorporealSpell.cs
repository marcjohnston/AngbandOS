internal class HighMageAttunementCorporealSpell : ClassSpell
{
    private HighMageAttunementCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellAttunement);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 25;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 160;
}