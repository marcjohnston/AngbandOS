[Serializable]
internal class MageSummonUndeadTarotSpell : ClassSpell
{
    private MageSummonUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonUndead);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 36;
    public override int ManaCost => 80;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}