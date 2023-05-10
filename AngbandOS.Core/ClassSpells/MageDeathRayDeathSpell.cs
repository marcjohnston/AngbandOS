[Serializable]
internal class MageDeathRayDeathSpell : ClassSpell
{
    private MageDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 20;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}