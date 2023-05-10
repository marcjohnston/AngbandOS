[Serializable]
internal class MageEtherealDivinationTarotSpell : ClassSpell
{
    private MageEtherealDivinationTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellEtherealDivination);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 50;
}