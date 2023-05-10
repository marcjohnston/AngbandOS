internal class MageKnowSelfCorporealSpell : ClassSpell
{
    private MageKnowSelfCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellKnowSelf);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 18;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 50;
}