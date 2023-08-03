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
    private HurtLotReward(SaveGame saveGame) : base(saveGame) { }
    public override void GetReward(Patron patron)
    {
        string wrathReason = $"the Wrath of {patron.ShortName}";
        SaveGame.MsgPrint($"The voice of {patron.ShortName} booms out:");
        SaveGame.MsgPrint("'Suffer, pathetic fool!'");
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get<DisintegrateProjectile>(), 0, SaveGame.ExperienceLevel * 4, 4);
        SaveGame.TakeHit(SaveGame.ExperienceLevel * 4, wrathReason);
    }
}