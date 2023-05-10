internal class PaladinHolyWordLifeSpell : ClassSpell
{
    private PaladinHolyWordLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHolyWord);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 38;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 125;
}