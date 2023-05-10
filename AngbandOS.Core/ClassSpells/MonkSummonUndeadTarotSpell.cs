[Serializable]
internal class MonkSummonUndeadTarotSpell : ClassSpell
{
    private MonkSummonUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonUndead);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 40;
    public override int ManaCost => 85;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}