internal class HighMageHealingTrueCorporealSpell : ClassSpell
{
    private HighMageHealingTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealingTrue);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 65;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 200;
}