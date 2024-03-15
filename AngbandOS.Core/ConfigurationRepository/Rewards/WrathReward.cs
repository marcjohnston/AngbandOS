// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

using System.Security.Cryptography.X509Certificates;

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class WrathReward : Reward
{
    private WrathReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        string wrathReason = $"the Wrath of {patron.ShortName}";
        SaveGame.MsgPrint($"The voice of {patron.ShortName} thunders:");
        SaveGame.MsgPrint("'Die, mortal!'");
        SaveGame.TakeHit(SaveGame.ExperienceLevel.Value * 4, wrathReason);
        for (int dummy = 0; dummy < 6; dummy++)
        {
            SaveGame.DecreaseAbilityScore(dummy, 10 + SaveGame.DieRoll(15), false);
        }
        SaveGame.ActivateHiSummon();
        SaveGame.ActivateDreadCurse();
        if (SaveGame.DieRoll(2) == 1)
        {
            SaveGame.CurseWeapon();
        }
        if (SaveGame.DieRoll(2) == 1)
        {
            SaveGame.CurseArmor();
        }
    }
}