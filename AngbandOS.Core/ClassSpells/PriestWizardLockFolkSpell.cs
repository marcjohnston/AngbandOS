internal class PriestWizardLockFolkSpell : ClassSpell
{
    private PriestWizardLockFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWizardLock);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}