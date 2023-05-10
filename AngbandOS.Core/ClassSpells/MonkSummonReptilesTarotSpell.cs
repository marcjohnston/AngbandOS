[Serializable]
internal class MonkSummonReptilesTarotSpell : ClassSpell
{
    private MonkSummonReptilesTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReptiles);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 27;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}