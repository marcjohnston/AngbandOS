internal class HighMageCharmMonsterSorcerySpell : ClassSpell
{
    private HighMageCharmMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellCharmMonster);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 8;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 40;
}