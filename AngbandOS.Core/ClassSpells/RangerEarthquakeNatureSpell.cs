[Serializable]
internal class RangerEarthquakeNatureSpell : ClassSpell
{
    private RangerEarthquakeNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEarthquake);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 28;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 150;
}