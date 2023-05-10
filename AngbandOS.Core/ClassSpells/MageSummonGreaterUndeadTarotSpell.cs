[Serializable]
internal class MageSummonGreaterUndeadTarotSpell : ClassSpell
{
    private MageSummonGreaterUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonGreaterUndead);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 100;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 220;
}