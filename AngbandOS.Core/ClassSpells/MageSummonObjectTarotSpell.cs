[Serializable]
internal class MageSummonObjectTarotSpell : ClassSpell
{
    private MageSummonObjectTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonObject);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 8;
}