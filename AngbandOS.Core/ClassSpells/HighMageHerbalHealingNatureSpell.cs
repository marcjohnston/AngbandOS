internal class HighMageHerbalHealingNatureSpell : ClassSpell
{
    private HighMageHerbalHealingNatureSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(NatureSpellHerbalHealing);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 80;
    public override int BaseFailure => 85;
    public override int FirstCastExperience => 50;
}