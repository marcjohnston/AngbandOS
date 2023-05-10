internal class HighMageFireBoltChaosSpell : ClassSpell
{
    private HighMageFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 10;
    public override int ManaCost => 5;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 6;
}