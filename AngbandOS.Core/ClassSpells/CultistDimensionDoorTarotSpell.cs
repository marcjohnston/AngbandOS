internal class CultistDimensionDoorTarotSpell : ClassSpell
{
    private CultistDimensionDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDimensionDoor);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 12;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}