internal class CultistDaylightNatureSpell : ClassSpell
{
    private CultistDaylightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDaylight);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}