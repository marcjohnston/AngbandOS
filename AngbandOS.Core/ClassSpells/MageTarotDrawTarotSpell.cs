[Serializable]
internal class MageTarotDrawTarotSpell : ClassSpell
{
    private MageTarotDrawTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTarotDraw);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}