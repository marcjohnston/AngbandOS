[Serializable]
internal class HighMageTrapAndDoorDestructionFolkSpell : ClassSpell
{
    private HighMageTrapAndDoorDestructionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 23;
    public override int FirstCastExperience => 7;
}