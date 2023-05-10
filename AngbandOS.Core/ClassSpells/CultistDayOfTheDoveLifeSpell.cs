internal class CultistDayOfTheDoveLifeSpell : ClassSpell
{
    private CultistDayOfTheDoveLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDayOfTheDove);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 36;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}