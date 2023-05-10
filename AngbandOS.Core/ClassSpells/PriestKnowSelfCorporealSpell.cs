internal class PriestKnowSelfCorporealSpell : ClassSpell
{
    private PriestKnowSelfCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellKnowSelf);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 50;
}