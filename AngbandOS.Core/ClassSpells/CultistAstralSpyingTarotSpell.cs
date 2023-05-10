[Serializable]
internal class CultistAstralSpyingTarotSpell : ClassSpell
{
    private CultistAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}