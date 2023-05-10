[Serializable]
internal class HighMageDeathDealingTarotSpell : ClassSpell
{
    private HighMageDeathDealingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDeathDealing);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 39;
    public override int ManaCost => 45;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 75;
}