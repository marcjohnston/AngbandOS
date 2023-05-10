[Serializable]
internal class RogueDetectionFolkSpell : ClassSpell
{
    private RogueDetectionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetection);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 44;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}