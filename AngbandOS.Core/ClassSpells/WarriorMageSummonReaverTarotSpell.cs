[Serializable]
internal class WarriorMageSummonReaverTarotSpell : ClassSpell
{
    private WarriorMageSummonReaverTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellSummonReaver);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 135;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 200;
}