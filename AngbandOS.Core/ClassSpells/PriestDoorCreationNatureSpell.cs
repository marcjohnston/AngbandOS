[Serializable]
internal class PriestDoorCreationNatureSpell : ClassSpell
{
    private PriestDoorCreationNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDoorCreation);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 28;
}