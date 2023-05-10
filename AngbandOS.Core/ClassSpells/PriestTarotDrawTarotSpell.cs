[Serializable]
internal class PriestTarotDrawTarotSpell : ClassSpell
{
    private PriestTarotDrawTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTarotDraw);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 5;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}