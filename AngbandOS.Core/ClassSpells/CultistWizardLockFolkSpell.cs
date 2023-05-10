[Serializable]
internal class CultistWizardLockFolkSpell : ClassSpell
{
    private CultistWizardLockFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellWizardLock);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 2;
    public override int ManaCost => 1;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 5;
}