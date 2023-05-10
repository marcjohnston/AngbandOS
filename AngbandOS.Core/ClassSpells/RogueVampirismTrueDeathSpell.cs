[Serializable]
internal class RogueVampirismTrueDeathSpell : ClassSpell
{
    private RogueVampirismTrueDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellVampirismTrue);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 46;
    public override int ManaCost => 45;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 40;
}