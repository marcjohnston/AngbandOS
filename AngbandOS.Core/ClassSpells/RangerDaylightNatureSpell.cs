[Serializable]
internal class RangerDaylightNatureSpell : ClassSpell
{
    private RangerDaylightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDaylight);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 7;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 3;
}