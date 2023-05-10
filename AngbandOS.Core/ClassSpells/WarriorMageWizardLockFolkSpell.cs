[Serializable]
internal class WarriorMageWizardLockFolkSpell : ClassSpell
{
    private WarriorMageWizardLockFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWizardLock);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}