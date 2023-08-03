// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.ActiveMutations;

[Serializable]
internal class ColdTouchActiveMutation : Mutation
{
    private ColdTouchActiveMutation(SaveGame saveGame) : base(saveGame) { }
    public override void Activate(SaveGame saveGame)
    {
        if (!saveGame.CheckIfRacialPowerWorks(2, 2, Ability.Constitution, 11))
        {
            return;
        }
        if (!saveGame.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = saveGame.MapY + saveGame.KeypadDirectionYOffset[dir];
        int x = saveGame.MapX + saveGame.KeypadDirectionXOffset[dir];
        GridTile cPtr = saveGame.Grid[y][x];
        if (cPtr.MonsterIndex == 0)
        {
            saveGame.MsgPrint("You wave your hands in the air.");
            return;
        }
        saveGame.FireBolt(saveGame.SingletonRepository.Projectiles.Get<ColdProjectile>(), dir, 2 * saveGame.ExperienceLevel);
    }

    public override string ActivationSummary(int lvl)
    {
        return lvl < 2 ? "cold touch       (unusable until level 2)" : "cold touch       (cost 2, CON based)";
    }

    public override int Frequency => 2;
    public override string GainMessage => "Your hands get very cold.";
    public override string HaveMessage => "You can freeze things with a touch.";
    public override string LoseMessage => "Your hands warm up.";
}