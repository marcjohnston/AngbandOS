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
    private PissOffReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        Game.MsgPrint($"The voice of {patron.ShortName} whispers:");
        Game.MsgPrint("'Now thou shalt pay for annoying me.'");
        switch (Game.DieRoll(4))
        {
            case 1:
                Game.ActivateDreadCurse();
                break;

            case 2:
                Game.ActivateHiSummon();
                break;

            case 3:
                if (Game.DieRoll(2) == 1)
                {
                    Game.CurseWeapon();
                }
                else
                {
                    Game.CurseArmor();
                }
                break;

            default:
                foreach (Ability ability in Game.SingletonRepository.Get<Ability>())
                {
                    Game.DecreaseAbilityScore(ability, 10 + Game.DieRoll(15), true);
                }
                break;
        }
    }
}