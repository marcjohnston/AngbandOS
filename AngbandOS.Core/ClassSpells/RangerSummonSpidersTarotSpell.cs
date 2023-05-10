[Serializable]
internal class RangerSummonSpidersTarotSpell : ClassSpell
{
    private RangerSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 28;
    public override int ManaCost => 26;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}