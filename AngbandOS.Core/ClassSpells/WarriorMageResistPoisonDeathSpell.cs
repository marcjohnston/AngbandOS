[Serializable]
internal class WarriorMageResistPoisonDeathSpell : ClassSpell
{
    private WarriorMageResistPoisonDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellResistPoison);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 9;
    public override int ManaCost => 10;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 6;
}