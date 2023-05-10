[Serializable]
internal class CultistSummonAncientDragonTarotSpell : ClassSpell
{
    private CultistSummonAncientDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAncientDragon);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 49;
    public override int ManaCost => 130;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}