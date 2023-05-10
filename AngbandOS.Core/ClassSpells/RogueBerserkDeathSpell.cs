internal class RogueBerserkDeathSpell : ClassSpell
{
    private RogueBerserkDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBerserk);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 20;
    public override int ManaCost => 25;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 100;
}