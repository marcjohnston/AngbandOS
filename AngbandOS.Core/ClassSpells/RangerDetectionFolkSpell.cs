[Serializable]
internal class RangerDetectionFolkSpell : ClassSpell
{
    private RangerDetectionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetection);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 44;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}