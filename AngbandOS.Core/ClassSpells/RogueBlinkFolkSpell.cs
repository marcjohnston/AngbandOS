[Serializable]
internal class RogueBlinkFolkSpell : ClassSpell
{
    private RogueBlinkFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellBlink);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 4;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}