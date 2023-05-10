internal class RogueCharmMonsterSorcerySpell : ClassSpell
{
    private RogueCharmMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellCharmMonster);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 10;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}