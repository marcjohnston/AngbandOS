[Serializable]
internal class RogueDetectDoorsAndTrapsFolkSpell : ClassSpell
{
    private RogueDetectDoorsAndTrapsFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectDoorsAndTraps);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 7;
}