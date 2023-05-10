[Serializable]
internal class RogueBattleFrenzyDeathSpell : ClassSpell
{
    private RogueBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBattleFrenzy);
    public override Type CharacterClass => typeof(RogueCharacterClass);
    public override int Level => 32;
    public override int ManaCost => 32;
    public override int BaseFailure => 80;
    public override int FirstCastExperience => 50;
}