[Serializable]
internal class WarriorMageSummonAnimalNatureSpell : ClassSpell
{
    private WarriorMageSummonAnimalNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellSummonAnimal);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 31;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 10;
}