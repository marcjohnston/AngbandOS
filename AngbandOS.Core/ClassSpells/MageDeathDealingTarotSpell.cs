[Serializable]
internal class MageDeathDealingTarotSpell : ClassSpell
{
    private MageDeathDealingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDeathDealing);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 50;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}