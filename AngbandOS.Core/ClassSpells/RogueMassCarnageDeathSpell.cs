[Serializable]
internal class RogueMassCarnageDeathSpell : ClassSpell
{
    private RogueMassCarnageDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellMassCarnage);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 99;
    public override int ManaCost => 0;
    public override int BaseFailure => 0;
    public override int FirstCastExperience => 0;
}