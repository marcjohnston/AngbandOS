internal class CultistSatisfyHungerLifeSpell : ClassSpell
{
    private CultistSatisfyHungerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSatisfyHunger);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 16;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 3;
}