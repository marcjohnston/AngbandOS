[Serializable]
internal class RogueSummonAncientDragonTarotSpell : ClassSpell
{
    private RogueSummonAncientDragonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonAncientDragon);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 99;
    public override int ManaCost => 0;
    public override int BaseFailure => 0;
    public override int FirstCastExperience => 0;
}