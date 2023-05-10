[Serializable]
internal class RangerDeathRayDeathSpell : ClassSpell
{
    private RangerDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 35;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}