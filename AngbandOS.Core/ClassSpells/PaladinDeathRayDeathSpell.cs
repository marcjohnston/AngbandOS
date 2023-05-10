[Serializable]
internal class PaladinDeathRayDeathSpell : ClassSpell
{
    private PaladinDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(PaladinCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 35;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}