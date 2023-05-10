internal class MageTrapAndDoorDestructionFolkSpell : ClassSpell
{
    private MageTrapAndDoorDestructionFolkSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(FolkSpellTrapAndDoorDestruction);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 33;
    public override int FirstCastExperience => 7;
}