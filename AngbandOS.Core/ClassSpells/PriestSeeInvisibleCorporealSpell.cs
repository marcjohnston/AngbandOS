internal class PriestSeeInvisibleCorporealSpell : ClassSpell
{
    private PriestSeeInvisibleCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSeeInvisible);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 16;
    public override int ManaCost => 14;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 6;
}