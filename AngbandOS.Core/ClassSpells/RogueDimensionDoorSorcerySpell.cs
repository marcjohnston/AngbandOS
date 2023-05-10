[Serializable]
internal class RogueDimensionDoorSorcerySpell : ClassSpell
{
    private RogueDimensionDoorSorcerySpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(SorcerySpellDimensionDoor);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 10;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}