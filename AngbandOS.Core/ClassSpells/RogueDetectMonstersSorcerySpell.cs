[Serializable]
internal class RogueDetectMonstersSorcerySpell : ClassSpell
{
    private RogueDetectMonstersSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDetectMonsters);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 1;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 1;
}