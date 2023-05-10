internal class HighMageInvokeSpiritsDeathSpell : ClassSpell
{
    private HighMageInvokeSpiritsDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellInvokeSpirits);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 10;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}