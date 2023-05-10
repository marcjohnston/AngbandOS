[Serializable]
internal class HighMageDimensionDoorTarotSpell : ClassSpell
{
    private HighMageDimensionDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDimensionDoor);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}