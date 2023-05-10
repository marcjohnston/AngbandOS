[Serializable]
internal class MageSummonSpidersTarotSpell : ClassSpell
{
    private MageSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}