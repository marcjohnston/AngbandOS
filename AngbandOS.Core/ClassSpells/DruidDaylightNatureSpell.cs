[Serializable]
internal class DruidDaylightNatureSpell : ClassSpell
{
    private DruidDaylightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDaylight);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 3;
    public override int ManaCost => 3;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}