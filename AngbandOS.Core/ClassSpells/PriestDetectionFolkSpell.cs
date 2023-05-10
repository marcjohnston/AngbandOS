internal class PriestDetectionFolkSpell : ClassSpell
{
    private PriestDetectionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetection);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 40;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}