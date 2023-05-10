[Serializable]
internal class WarriorMageChaosBoltChaosSpell : ClassSpell
{
    private WarriorMageChaosBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellChaosBolt);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 23;
    public override int ManaCost => 22;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 9;
}