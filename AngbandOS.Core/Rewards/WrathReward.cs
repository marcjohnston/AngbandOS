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
    private WrathReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        string wrathReason = $"the Wrath of {patron.ShortName}";
        Game.MsgPrint($"The voice of {patron.ShortName} thunders:");
        Game.MsgPrint("'Die, mortal!'");
        Game.TakeHit(Game.ExperienceLevel.IntValue * 4, wrathReason);
        foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
        {
            Game.DecreaseAbilityScore(ability, 10 + Game.DieRoll(15), false);
        }
        Game.ActivateHiSummon();
        Game.ActivateDreadCurse();
        if (Game.DieRoll(2) == 1)
        {
            Game.CurseWeapon();
        }
        if (Game.DieRoll(2) == 1)
        {
            Game.CurseArmor();
        }
    }
}