internal class PriestDayOfTheDoveLifeSpell : ClassSpell
{
    private PriestDayOfTheDoveLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDayOfTheDove);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 20;
    public override int BaseFailure => 55;
    public override int FirstCastExperience => 70;
}