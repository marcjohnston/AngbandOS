// AngbandOS: 2022 Marc Johnston
//
// This game is released under the �Angband License�, defined as: �� 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.�

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class ChaosWpReward : Reward
{
    private ChaosWpReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Thy deed hath earned thee a worthy blade.'");
        ItemFactory reward;
        switch (SaveGame.Rng.DieRoll(SaveGame.ExperienceLevel))
        {
            case 1:
            case 2:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordDagger>();
                break;

            case 3:
            case 4:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordMainGauche>();
                break;

            case 5:
            case 6:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordRapier>();
                break;

            case 7:
            case 8:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordSmallSword>();
                break;

            case 9:
            case 10:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordShortSword>();
                break;

            case 11:
            case 12:
            case 13:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordSabre>();
                break;

            case 14:
            case 15:
            case 16:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordCutlass>();
                break;

            case 17:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordTulwar>();
                break;

            case 18:
            case 19:
            case 20:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordBroadSword>();
                break;

            case 21:
            case 22:
            case 23:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordLongSword>();
                break;

            case 24:
            case 25:
            case 26:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordScimitar>();
                break;

            case 27:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordKatana>();
                break;

            case 28:
            case 29:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordBastardSword>();
                break;

            case 30:
            case 31:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordTwoHandedSword>();
                break;

            case 32:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordExecutionersSword>();
                break;

            default:
                reward = SaveGame.SingletonRepository.ItemFactories.Get<SwordBladeOfChaos>();
                break;
        }
        Item qPtr = reward.CreateItem();
        qPtr.BonusToHit = 3 + (SaveGame.Rng.DieRoll(SaveGame.Difficulty) % 10);
        qPtr.BonusDamage = 3 + (SaveGame.Rng.DieRoll(SaveGame.Difficulty) % 10);
        qPtr.ApplyRandomResistance(SaveGame.Rng.DieRoll(34) + 4);
        qPtr.RareItemTypeIndex = RareItemTypeEnum.WeaponChaotic;
        SaveGame.DropNear(qPtr, -1, SaveGame.MapY, SaveGame.MapX);
    }
}