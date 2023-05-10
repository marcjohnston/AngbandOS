internal class RangerBurnResistanceCorporealSpell : ClassSpell
{
    private RangerBurnResistanceCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellBurnResistance);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 19;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 4;
}