internal class RogueConfuseMonsterSorcerySpell : ClassSpell
{
    private RogueConfuseMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellConfuseMonster);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 6;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 1;
}