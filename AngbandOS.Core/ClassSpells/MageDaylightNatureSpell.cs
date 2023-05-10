internal class MageDaylightNatureSpell : ClassSpell
{
    private MageDaylightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDaylight);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}