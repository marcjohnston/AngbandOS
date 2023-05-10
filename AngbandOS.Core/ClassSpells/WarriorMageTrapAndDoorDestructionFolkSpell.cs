internal class WarriorMageTrapAndDoorDestructionFolkSpell : ClassSpell
{
    private WarriorMageTrapAndDoorDestructionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 7;
}