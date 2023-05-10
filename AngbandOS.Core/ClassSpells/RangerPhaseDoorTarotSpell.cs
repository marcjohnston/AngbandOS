[Serializable]
internal class RangerPhaseDoorTarotSpell : ClassSpell
{
    private RangerPhaseDoorTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellPhaseDoor);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 1;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}