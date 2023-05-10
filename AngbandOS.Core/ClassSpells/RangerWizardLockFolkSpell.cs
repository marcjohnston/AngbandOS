[Serializable]
internal class RangerWizardLockFolkSpell : ClassSpell
{
    private RangerWizardLockFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWizardLock);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 2;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}