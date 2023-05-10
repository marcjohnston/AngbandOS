[Serializable]
internal class WarriorMageSummonGreaterUndeadTarotSpell : ClassSpell
{
    private WarriorMageSummonGreaterUndeadTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonGreaterUndead);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 135;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 220;
}