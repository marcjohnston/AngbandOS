[Serializable]
internal class CultistDimensionDoorSorcerySpell : ClassSpell
{
    private CultistDimensionDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDimensionDoor);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 12;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}