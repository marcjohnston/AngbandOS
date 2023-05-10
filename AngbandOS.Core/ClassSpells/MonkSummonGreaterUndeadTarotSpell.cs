internal class MonkSummonGreaterUndeadTarotSpell : ClassSpell
{
    private MonkSummonGreaterUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonGreaterUndead);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 125;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 220;
}