[Serializable]
internal class RogueDeathRayDeathSpell : ClassSpell
{
    private RogueDeathRayDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellDeathRay);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}