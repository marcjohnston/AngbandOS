[Serializable]
internal class WarriorMageMassCarnageDeathSpell : ClassSpell
{
    private WarriorMageMassCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMassCarnage);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 48;
    public override int ManaCost => 85;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}