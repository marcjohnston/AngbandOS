internal class DruidDoorCreationNatureSpell : ClassSpell
{
    private DruidDoorCreationNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDoorCreation);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 10;
    public override int FirstCastExperience => 28;
}