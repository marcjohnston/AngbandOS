[Serializable]
internal class PriestSummonSpidersTarotSpell : ClassSpell
{
    private PriestSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 27;
    public override int ManaCost => 25;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}