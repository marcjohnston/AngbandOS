internal class MageDimensionDoorSorcerySpell : ClassSpell
{
    private MageDimensionDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDimensionDoor);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 40;
}