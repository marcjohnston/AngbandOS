[Serializable]
internal class MonkTeleportSelfChaosSpell : ClassSpell
{
    private MonkTeleportSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportSelf);
    public override Type CharacterClass => typeof(MonkCharacterClass);
    public override int Level => 18;
    public override int ManaCost => 17;
    public override int BaseFailure => 35;
    public override int FirstCastExperience => 5;
}