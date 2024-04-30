// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Rewards;

[Serializable]
internal class HurtLotReward : Reward
{
    private HurtLotReward(Game game) : base(game) { }
    public override void GetReward(Patron patron)
    {
        string wrathReason = $"the Wrath of {patron.ShortName}";
        Game.MsgPrint($"The voice of {patron.ShortName} booms out:");
        Game.MsgPrint("'Suffer, pathetic fool!'");
        Game.FireBall(Game.SingletonRepository.Get<Projectile>(nameof(DisintegrateProjectile)), 0, Game.ExperienceLevel.IntValue * 4, 4);
        Game.TakeHit(Game.ExperienceLevel.IntValue * 4, wrathReason);
    }
}