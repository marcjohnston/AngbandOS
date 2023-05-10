internal class RangerSatisfyHungerCorporealSpell : ClassSpell
{
    private RangerSatisfyHungerCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellSatisfyHunger);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 17;
    public override int ManaCost => 17;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 4;
}