internal class HighMageDispelCurseLifeSpell : ClassSpell
{
    private HighMageDispelCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelCurse);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 150;
}