[Serializable]
internal class HighMageBattleFrenzyDeathSpell : ClassSpell
{
    private HighMageBattleFrenzyDeathSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(DeathSpellBattleFrenzy);
    public override Type CharacterClass => typeof(HighMageCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 20;
    public override int BaseFailure => 65;
    public override int FirstCastExperience => 50;
}