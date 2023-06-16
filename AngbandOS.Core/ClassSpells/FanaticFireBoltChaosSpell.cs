// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

[Serializable]
internal class FanaticFireBoltChaosSpell : ClassSpell
{
    private FanaticFireBoltChaosSpell(SaveGame saveGame) : base(saveGame) { }
    public override Type Spell => typeof(ChaosSpellFireBolt);
    public override Type CharacterClass => typeof(FanaticCharacterClass);
    public override int Level => 8;
    public override int ManaCost => 7;
    public override int BaseFailure => 45;
    public override int FirstCastExperience => 5;
}