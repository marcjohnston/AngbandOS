[Serializable]
internal class RogueWizardLockFolkSpell : ClassSpell
{
    private RogueWizardLockFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWizardLock);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 2;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}