[Serializable]
internal class WarriorMageFlameStrikeChaosSpell : ClassSpell
{
    private WarriorMageFlameStrikeChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFlameStrike);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 42;
    public override int ManaCost => 40;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 40;
}