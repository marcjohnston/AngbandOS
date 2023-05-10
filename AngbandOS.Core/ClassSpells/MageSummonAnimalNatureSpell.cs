internal class MageSummonAnimalNatureSpell : ClassSpell
{
    private MageSummonAnimalNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellSummonAnimal);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 50;
}