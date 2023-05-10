[Serializable]
internal class MageDetectInvisibilityFolkSpell : ClassSpell
{
    private MageDetectInvisibilityFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectInvisibility);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 4;
}