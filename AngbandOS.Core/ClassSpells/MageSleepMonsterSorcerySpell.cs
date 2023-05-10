internal class MageSleepMonsterSorcerySpell : ClassSpell
{
    private MageSleepMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSleepMonster);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 4;
}