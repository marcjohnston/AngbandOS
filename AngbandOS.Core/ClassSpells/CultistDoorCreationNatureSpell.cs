[Serializable]
internal class CultistDoorCreationNatureSpell : ClassSpell
{
    private CultistDoorCreationNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDoorCreation);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 28;
}