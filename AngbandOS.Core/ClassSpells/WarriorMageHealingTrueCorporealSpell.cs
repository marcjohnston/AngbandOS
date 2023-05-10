[Serializable]
internal class WarriorMageHealingTrueCorporealSpell : ClassSpell
{
    private WarriorMageHealingTrueCorporealSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(CorporealSpellHealingTrue);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 85;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 200;
}