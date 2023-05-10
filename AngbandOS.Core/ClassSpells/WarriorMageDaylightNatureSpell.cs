[Serializable]
internal class WarriorMageDaylightNatureSpell : ClassSpell
{
    private WarriorMageDaylightNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellDaylight);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}