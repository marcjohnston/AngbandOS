[Serializable]
internal class WarriorMageEarthquakeNatureSpell : ClassSpell
{
    private WarriorMageEarthquakeNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEarthquake);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 25;
}