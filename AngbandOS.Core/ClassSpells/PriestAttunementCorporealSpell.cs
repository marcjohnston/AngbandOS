internal class PriestAttunementCorporealSpell : ClassSpell
{
    private PriestAttunementCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellAttunement);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 30;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 160;
}