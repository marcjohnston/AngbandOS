[Serializable]
internal class WarriorMageMassSummonsTarotSpell : ClassSpell
{
    private WarriorMageMassSummonsTarotSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(TarotSpellMassSummons);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 120;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 200;
}