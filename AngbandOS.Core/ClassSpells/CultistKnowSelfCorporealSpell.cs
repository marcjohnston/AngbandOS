internal class CultistKnowSelfCorporealSpell : ClassSpell
{
    private CultistKnowSelfCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellKnowSelf);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 19;
    public override int ManaCost => 19;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 50;
}