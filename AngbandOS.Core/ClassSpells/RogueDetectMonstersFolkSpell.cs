[Serializable]
internal class RogueDetectMonstersFolkSpell : ClassSpell
{
    private RogueDetectMonstersFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectMonsters);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 3;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}