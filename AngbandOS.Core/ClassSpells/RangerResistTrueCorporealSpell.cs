internal class RangerResistTrueCorporealSpell : ClassSpell
{
    private RangerResistTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellResistTrue);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 40;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 10;
}