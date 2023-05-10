[Serializable]
internal class MageDimensionDoorTarotSpell : ClassSpell
{
    private MageDimensionDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDimensionDoor);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 9;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}