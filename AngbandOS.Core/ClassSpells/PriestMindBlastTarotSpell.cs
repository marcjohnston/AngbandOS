[Serializable]
internal class PriestMindBlastTarotSpell : ClassSpell
{
    private PriestMindBlastTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMindBlast);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 4;
    public override int ManaCost => 4;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 4;
}