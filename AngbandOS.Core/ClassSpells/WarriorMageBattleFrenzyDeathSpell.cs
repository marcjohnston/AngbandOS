[Serializable]
internal class WarriorMageBattleFrenzyDeathSpell : ClassSpell
{
    private WarriorMageBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBattleFrenzy);
    public override Type CharacterClass => typeof(WarriorMageCharacterClass);
    public override int Level => 30;
    public override int ManaCost => 30;
    public override int BaseFailure => 75;
    public override int FirstCastExperience => 50;
}