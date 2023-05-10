internal class HighMageSleepMonsterSorcerySpell : ClassSpell
{
    private HighMageSleepMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSleepMonster);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 4;
}