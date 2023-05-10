internal class PriestSummonAnimalNatureSpell : ClassSpell
{
    private PriestSummonAnimalNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellSummonAnimal);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 8;
}