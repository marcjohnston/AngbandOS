internal class PriestHeroismCorporealSpell : ClassSpell
{
    private PriestHeroismCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHeroism);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 13;
    public override int ManaCost => 13;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 20;
}