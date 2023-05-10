[Serializable]
internal class RangerMindBlastTarotSpell : ClassSpell
{
    private RangerMindBlastTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMindBlast);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 6;
    public override int ManaCost => 6;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}