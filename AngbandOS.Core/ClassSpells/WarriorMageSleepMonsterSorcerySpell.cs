[Serializable]
internal class WarriorMageSleepMonsterSorcerySpell : ClassSpell
{
    private WarriorMageSleepMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSleepMonster);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}