[Serializable]
internal class WarriorMageSummonDemonTarotSpell : ClassSpell
{
    private WarriorMageSummonDemonTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonDemon);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 125;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 150;
}