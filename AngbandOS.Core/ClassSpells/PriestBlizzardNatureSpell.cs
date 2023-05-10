internal class PriestBlizzardNatureSpell : ClassSpell
{
    private PriestBlizzardNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellBlizzard);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 27;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 29;
}