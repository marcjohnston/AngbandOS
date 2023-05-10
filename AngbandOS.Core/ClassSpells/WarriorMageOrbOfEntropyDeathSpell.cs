[Serializable]
internal class WarriorMageOrbOfEntropyDeathSpell : ClassSpell
{
    private WarriorMageOrbOfEntropyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellOrbOfEntropy);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 14;
    public override int ManaCost => 14;
    public override int BaseFailure => 40;
    public override int FirstCastExperience => 5;
}