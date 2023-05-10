internal class RogueEsoteriaDeathSpell : ClassSpell
{
    private RogueEsoteriaDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellEsoteria);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 40;
    public override int BaseFailure => 90;
    public override int FirstCastExperience => 250;
}