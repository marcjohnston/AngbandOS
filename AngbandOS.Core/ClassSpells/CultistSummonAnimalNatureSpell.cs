[Serializable]
internal class CultistSummonAnimalNatureSpell : ClassSpell
{
    private CultistSummonAnimalNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellSummonAnimal);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 31;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 10;
}