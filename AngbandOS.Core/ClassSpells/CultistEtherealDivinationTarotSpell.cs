[Serializable]
internal class CultistEtherealDivinationTarotSpell : ClassSpell
{
    private CultistEtherealDivinationTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellEtherealDivination);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 33;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 50;
}