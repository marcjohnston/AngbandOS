// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class PissOffReward : Reward
{
    private PissOffReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        SaveGame.MsgPrint($"The voice of {patron.ShortName} whispers:");
        SaveGame.MsgPrint("'Now thou shalt pay for annoying me.'");
        switch (Program.Rng.DieRoll(4))
        {
            case 1:
                SaveGame.ActivateDreadCurse();
                break;

            case 2:
                SaveGame.ActivateHiSummon();
                break;

            case 3:
                if (Program.Rng.DieRoll(2) == 1)
                {
                    SaveGame.CurseWeapon();
                }
                else
                {
                    SaveGame.CurseArmour();
                }
                break;

            default:
                for (int dummy = 0; dummy < 6; dummy++)
                {
                    SaveGame.DecreaseAbilityScore(dummy, 10 + Program.Rng.DieRoll(15), true);
                }
                break;
        }
    }
}