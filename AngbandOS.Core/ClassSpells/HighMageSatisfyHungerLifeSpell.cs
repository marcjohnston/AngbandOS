[Serializable]
internal class HighMageSatisfyHungerLifeSpell : ClassSpell
{
    private HighMageSatisfyHungerLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellSatisfyHunger);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 12;
    public override int ManaCost => 10;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 3;
}