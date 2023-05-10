[Serializable]
internal class MonkDimensionDoorTarotSpell : ClassSpell
{
    private MonkDimensionDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDimensionDoor);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 11;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}