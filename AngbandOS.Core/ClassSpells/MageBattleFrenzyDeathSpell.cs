[Serializable]
internal class MageBattleFrenzyDeathSpell : ClassSpell
{
    private MageBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBattleFrenzy);
    public override Type CharacterClass => typeof(MageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 25;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}