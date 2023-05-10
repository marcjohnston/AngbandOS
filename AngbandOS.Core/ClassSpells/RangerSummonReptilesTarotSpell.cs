[Serializable]
internal class RangerSummonReptilesTarotSpell : ClassSpell
{
    private RangerSummonReptilesTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReptiles);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 31;
    public override int ManaCost => 30;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}