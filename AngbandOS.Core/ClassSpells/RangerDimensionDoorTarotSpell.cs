[Serializable]
internal class RangerDimensionDoorTarotSpell : ClassSpell
{
    private RangerDimensionDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDimensionDoor);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}