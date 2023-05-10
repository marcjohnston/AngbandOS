internal class HighMageRemoveCurseLifeSpell : ClassSpell
{
    private HighMageRemoveCurseLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellRemoveCurse);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 12;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}