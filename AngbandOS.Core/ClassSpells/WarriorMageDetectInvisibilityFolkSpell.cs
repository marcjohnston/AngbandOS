internal class WarriorMageDetectInvisibilityFolkSpell : ClassSpell
{
    private WarriorMageDetectInvisibilityFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellDetectInvisibility);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 2;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 4;
}