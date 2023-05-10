internal class PriestAnimalTamingNatureSpell : ClassSpell
{
    private PriestAnimalTamingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellAnimalTaming);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 5;
}