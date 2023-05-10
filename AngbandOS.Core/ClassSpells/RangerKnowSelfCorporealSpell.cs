internal class RangerKnowSelfCorporealSpell : ClassSpell
{
    private RangerKnowSelfCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellKnowSelf);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 25;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 20;
}