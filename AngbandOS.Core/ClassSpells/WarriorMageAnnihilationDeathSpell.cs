[Serializable]
internal class WarriorMageAnnihilationDeathSpell : ClassSpell
{
    private WarriorMageAnnihilationDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellAnnihilation);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 100;
    public override int BaseFailure => 95;
    public override int FirstCastExperience => 250;
}