[Serializable]
internal class WarriorMageAstralSpyingTarotSpell : ClassSpell
{
    private WarriorMageAstralSpyingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellAstralSpying);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 15;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 6;
}