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
        SaveGame.Player.TakeHit(SaveGame.Player.Level * 4, wrathReason);
        for (int dummy = 0; dummy < 6; dummy++)
        {
            SaveGame.Player.DecreaseAbilityScore(dummy, 10 + Program.Rng.DieRoll(15), false);
        }
        SaveGame.ActivateHiSummon();
        SaveGame.ActivateDreadCurse();
        if (Program.Rng.DieRoll(2) == 1)
        {
            SaveGame.CurseWeapon();
        }
        if (Program.Rng.DieRoll(2) == 1)
        {
            SaveGame.CurseArmour();
        }
    }
}