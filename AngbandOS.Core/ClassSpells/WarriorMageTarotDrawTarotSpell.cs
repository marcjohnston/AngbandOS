[Serializable]
internal class WarriorMageTarotDrawTarotSpell : ClassSpell
{
    private WarriorMageTarotDrawTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellTarotDraw);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 7;
    public override int ManaCost => 7;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 8;
}