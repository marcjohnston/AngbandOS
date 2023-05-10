[Serializable]
internal class RogueTarotDrawTarotSpell : ClassSpell
{
    private RogueTarotDrawTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTarotDraw);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}