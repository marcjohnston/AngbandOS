internal class RangerSummonAnimalNatureSpell : ClassSpell
{
    private RangerSummonAnimalNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellSummonAnimal);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 23;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 10;
}