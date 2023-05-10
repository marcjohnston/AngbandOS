[Serializable]
internal class DruidSummonAnimalNatureSpell : ClassSpell
{
    private DruidSummonAnimalNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellSummonAnimal);
    public override Type CharacterClass => typeof(DruidCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}