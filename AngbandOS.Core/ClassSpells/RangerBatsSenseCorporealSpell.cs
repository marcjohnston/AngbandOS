internal class RangerBatsSenseCorporealSpell : ClassSpell
{
    private RangerBatsSenseCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBatsSense);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 4;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 2;
}