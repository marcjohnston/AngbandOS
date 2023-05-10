[Serializable]
internal class CultistSleepMonsterSorcerySpell : ClassSpell
{
    private CultistSleepMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSleepMonster);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 4;
}