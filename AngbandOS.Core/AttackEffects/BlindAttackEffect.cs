// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.AttackEffects;

[Serializable]
internal class BlindAttackEffect : AttackEffect
{
    private BlindAttackEffect(SaveGame saveGame) : base(saveGame) { }
    public override int Power => 2;
    public override string Description => "blind";
    public override void ApplyToPlayer(int monsterLevel, int monsterIndex, int armorClass, string monsterDescription, Monster monster, ref bool obvious, ref int damage, ref bool blinked)
    {
        SaveGame.TakeHit(damage, monsterDescription);
        if (!SaveGame.HasBlindnessResistance)
        {
            if (SaveGame.BlindnessTimer.AddTimer(10 + SaveGame.DieRoll(monsterLevel)))
            {
                obvious = true;
            }
        }
        SaveGame.UpdateSmartLearn(monster, SaveGame.SingletonRepository.SpellResistantDetections.Get(nameof(BlindSpellResistantDetection)));
    }
}