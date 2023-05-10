[Serializable]
internal class WarriorMageDispelUndeadAndDemonsLifeSpell : ClassSpell
{
    private WarriorMageDispelUndeadAndDemonsLifeSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(LifeSpellDispelUndeadAndDemons);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 34;
    public override int ManaCost => 34;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 75;
}