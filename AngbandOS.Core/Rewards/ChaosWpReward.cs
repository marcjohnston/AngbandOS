// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Rewards;

[Serializable]
internal class ChaosWpReward : Reward
{
    private ChaosWpReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} booms out:");
        Game.MsgPrint("'Thy deed hath earned thee a worthy blade.'");
        ItemFactory reward;
        switch (Game.DieRoll(Game.ExperienceLevel.IntValue))
        {
            case 1:
            case 2:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(DaggerWeaponItemFactory));
                break;

            case 3:
            case 4:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(MainGaucheWeaponItemFactory));
                break;

            case 5:
            case 6:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(RapierWeaponItemFactory));
                break;

            case 7:
            case 8:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(SmallSwordWeaponItemFactory));
                break;

            case 9:
            case 10:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(ShortSwordWeaponItemFactory));
                break;

            case 11:
            case 12:
            case 13:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(SabreWeaponItemFactory));
                break;

            case 14:
            case 15:
            case 16:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(CutlassWeaponItemFactory));
                break;

            case 17:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(TulwarWeaponItemFactory));
                break;

            case 18:
            case 19:
            case 20:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(BroadSwordWeaponItemFactory));
                break;

            case 21:
            case 22:
            case 23:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(LongSwordWeaponItemFactory));
                break;

            case 24:
            case 25:
            case 26:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(ScimitarWeaponItemFactory));
                break;

            case 27:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(KatanaWeaponItemFactory));
                break;

            case 28:
            case 29:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(BastardSwordWeaponItemFactory));
                break;

            case 30:
            case 31:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(TwoHandedSwordWeaponItemFactory));
                break;

            case 32:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(ExecutionersSwordWeaponItemFactory));
                break;

            default:
                reward = Game.SingletonRepository.Get<ItemFactory>(nameof(BladeOfChaosWeaponItemFactory));
                break;
        }
        Item qPtr = reward.GenerateItem();
        qPtr.EffectivePropertySet.BonusHit = 3 + (Game.DieRoll(Game.Difficulty) % 10);
        qPtr.EffectivePropertySet.BonusDamage = 3 + (Game.DieRoll(Game.Difficulty) % 10);
        qPtr.ApplyRandomResistance(Game.SingletonRepository.Get<ItemEnhancementWeightedRandom>(nameof(ResistanceAndBiasItemEnhancementWeightedRandom)));
        qPtr.SetRareItem(Game.SingletonRepository.Get<ItemEnhancement>(nameof(WeaponChaoticItemEnhancement)));
        Game.DropNear(qPtr, null, Game.MapY.IntValue, Game.MapX.IntValue);
    }
}