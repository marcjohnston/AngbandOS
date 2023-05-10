internal class HighMageSummonAncientDragonTarotSpell : ClassSpell
{
    private HighMageSummonAncientDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAncientDragon);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 44;
    public override int ManaCost => 90;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 200;
}