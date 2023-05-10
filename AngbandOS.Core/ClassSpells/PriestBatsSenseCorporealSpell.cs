internal class PriestBatsSenseCorporealSpell : ClassSpell
{
    private PriestBatsSenseCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBatsSense);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 4;
    public override int BaseFailure => 30;
    public override int FirstCastExperience => 1;
}