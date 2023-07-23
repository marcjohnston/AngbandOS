// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Items;

[Serializable]
internal class LordlyProtectionRingItem : RingItem
{
    public LordlyProtectionRingItem(SaveGame saveGame) : base(saveGame, saveGame.SingletonRepository.ItemFactories.Get<LordlyProtectionRingItemFactory>()) { }
    protected override void ApplyMagic(int level, int power, Store? store)
    {
        IArtifactBias artifactBias = null;
        do
        {
            ApplyRandomResistance(ref artifactBias, Program.Rng.DieRoll(20) + 18);
        } while (Program.Rng.DieRoll(4) == 1);
        BonusArmorClass = 10 + Program.Rng.DieRoll(5) + GetBonusValue(10, level);
        if (SaveGame.Level != null)
        {
            SaveGame.TreasureRating += 5;
        }
    }
}