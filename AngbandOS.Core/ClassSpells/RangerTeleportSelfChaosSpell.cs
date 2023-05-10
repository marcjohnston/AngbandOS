[Serializable]
internal class RangerTeleportSelfChaosSpell : ClassSpell
{
    private RangerTeleportSelfChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportSelf);
    public override Type CharacterClass => typeof(RangerCharacterClass);
    public override int Level => 25;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 3;
}