[Serializable]
internal class RogueWraithformDeathSpell : ClassSpell
{
    private RogueWraithformDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellWraithform);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 50;
    public override int ManaCost => 125;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}