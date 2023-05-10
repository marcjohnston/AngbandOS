[Serializable]
internal class CultistSummonDragonTarotSpell : ClassSpell
{
    private CultistSummonDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDragon);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 95;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}