internal class RogueSleepMonsterSorcerySpell : ClassSpell
{
    private RogueSleepMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSleepMonster);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 9;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 1;
}