[Serializable]
internal class CultistMindBlastTarotSpell : ClassSpell
{
    private CultistMindBlastTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMindBlast);
    public override Type CharacterClass => typeof(CultistCharacterClass);
    public override int Level => 5;
    public override int ManaCost => 5;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}