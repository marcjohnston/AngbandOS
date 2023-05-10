internal class RangerMutateBodyCorporealSpell : ClassSpell
{
    private RangerMutateBodyCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellMutateBody);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 25;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 20;
}