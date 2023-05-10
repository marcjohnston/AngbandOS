internal class RogueDetectInvisibilityFolkSpell : ClassSpell
{
    private RogueDetectInvisibilityFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectInvisibility);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 3;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 4;
}