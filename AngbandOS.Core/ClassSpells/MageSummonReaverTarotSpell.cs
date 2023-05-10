[Serializable]
internal class MageSummonReaverTarotSpell : ClassSpell
{
    private MageSummonReaverTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReaver);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 45;
    public override int ManaCost => 100;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}