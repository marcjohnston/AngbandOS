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
    private ColdTouchActiveMutation(Game game) : base(game) { }
    public override void Activate()
    {
        if (!Game.CheckIfRacialPowerWorks(2, 2, Game.ConstitutionAbility, 11))
        {
            return;
        }
        if (!Game.GetDirectionNoAim(out int dir))
        {
            return;
        }
        int y = Game.MapY.IntValue + Game.KeypadDirectionYOffset[dir];
        int x = Game.MapX.IntValue + Game.KeypadDirectionXOffset[dir];
        GridTile cPtr = Game.Map.Grid[y][x];
        if (cPtr.MonsterIndex == 0)
        {
            Game.MsgPrint("You wave your hands in the air.");
            return;
        }
        Game.FireBolt(Game.SingletonRepository.Get<Projectile>(nameof(ColdProjectile)), dir, 2 * Game.ExperienceLevel.IntValue);
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