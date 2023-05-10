internal class PriestResistTrueCorporealSpell : ClassSpell
{
    private PriestResistTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellResistTrue);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 33;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 20;
}