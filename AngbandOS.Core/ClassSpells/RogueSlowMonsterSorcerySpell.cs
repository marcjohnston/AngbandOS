[Serializable]
internal class RogueSlowMonsterSorcerySpell : ClassSpell
{
    private RogueSlowMonsterSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellSlowMonster);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 17;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 2;
}