[Serializable]
internal class WarriorMageDeathDealingTarotSpell : ClassSpell
{
    private WarriorMageDeathDealingTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellDeathDealing);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 55;
    public override int BaseFailure => 50;
    public override int FirstCastExperience => 75;
}