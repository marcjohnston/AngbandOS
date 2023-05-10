[Serializable]
internal class RogueDimensionDoorTarotSpell : ClassSpell
{
    private RogueDimensionDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDimensionDoor);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 13;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}