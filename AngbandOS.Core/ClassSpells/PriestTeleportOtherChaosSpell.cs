[Serializable]
internal class PriestTeleportOtherChaosSpell : ClassSpell
{
    private PriestTeleportOtherChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellTeleportOther);
    public override Type CharacterClass => typeof(PriestCharacterClass);
    public override int Level => 29;
    public override int ManaCost => 22;
    public override int BaseFailure => 60;
    public override int FirstCastExperience => 8;
}