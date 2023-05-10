[Serializable]
internal class HighMageDoorCreationNatureSpell : ClassSpell
{
    private HighMageDoorCreationNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDoorCreation);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 10;
    public override int FirstCastExperience => 28;
}