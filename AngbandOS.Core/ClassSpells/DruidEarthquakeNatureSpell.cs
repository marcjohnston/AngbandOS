[Serializable]
internal class DruidEarthquakeNatureSpell : ClassSpell
{
    private DruidEarthquakeNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellEarthquake);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 15;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 25;
}