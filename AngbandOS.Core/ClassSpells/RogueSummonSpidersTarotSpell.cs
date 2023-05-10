[Serializable]
internal class RogueSummonSpidersTarotSpell : ClassSpell
{
    private RogueSummonSpidersTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonSpiders);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 25;
}