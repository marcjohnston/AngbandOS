[Serializable]
internal class MageWizardLockFolkSpell : ClassSpell
{
    private MageWizardLockFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWizardLock);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 1;
    public override int ManaCost => 1;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}