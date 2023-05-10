[Serializable]
internal class RogueSummonObjectTarotSpell : ClassSpell
{
    private RogueSummonObjectTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonObject);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 22;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}