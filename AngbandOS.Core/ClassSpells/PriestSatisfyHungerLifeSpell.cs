internal class PriestSatisfyHungerLifeSpell : ClassSpell
{
    private PriestSatisfyHungerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSatisfyHunger);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 5;
    public override int BaseFailure => 38;
    public override int FirstCastExperience => 4;
}