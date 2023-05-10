[Serializable]
internal class WarriorMageDeathRayDeathSpell : ClassSpell
{
    private WarriorMageDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 24;
    public override int ManaCost => 24;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}