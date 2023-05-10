internal class PriestHeroismLifeSpell : ClassSpell
{
    private PriestHeroismLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellHeroism);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}