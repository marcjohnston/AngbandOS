internal class HighMageResistTrueCorporealSpell : ClassSpell
{
    private HighMageResistTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellResistTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 20;
}