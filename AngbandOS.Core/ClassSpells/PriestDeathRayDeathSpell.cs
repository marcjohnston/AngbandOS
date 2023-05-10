[Serializable]
internal class PriestDeathRayDeathSpell : ClassSpell
{
    private PriestDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}