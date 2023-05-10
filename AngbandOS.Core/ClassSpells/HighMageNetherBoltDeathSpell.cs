internal class HighMageNetherBoltDeathSpell : ClassSpell
{
    private HighMageNetherBoltDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellNetherBolt);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 11;
    public override int ManaCost => 10;
    public override int BaseFailure => 20;
    public override int FirstCastExperience => 5;
}