internal class MageDoorCreationNatureSpell : ClassSpell
{
    private MageDoorCreationNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDoorCreation);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 28;
}