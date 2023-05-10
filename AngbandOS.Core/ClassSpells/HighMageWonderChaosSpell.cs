internal class HighMageWonderChaosSpell : ClassSpell
{
    private HighMageWonderChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellWonder);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 15;
    public override int ManaCost => 9;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 5;
}