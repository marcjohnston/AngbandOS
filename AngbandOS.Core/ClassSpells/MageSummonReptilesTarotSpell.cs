[Serializable]
internal class MageSummonReptilesTarotSpell : ClassSpell
{
    private MageSummonReptilesTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReptiles);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 26;
    public override int ManaCost => 26;
    public override int BaseFailure => 70;
    public override int FirstCastExperience => 30;
}