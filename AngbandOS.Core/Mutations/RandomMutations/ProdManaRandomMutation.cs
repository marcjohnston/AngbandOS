// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using AngbandOS.GamePacks.Cthangband;

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class ProdManaRandomMutation : Mutation
{
    private ProdManaRandomMutation(Game game) : base(game) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start producing magical energy uncontrollably.";
    public override string HaveMessage => "You are producing magical energy uncontrollably.";
    public override string LoseMessage => "You stop producing magical energy uncontrollably.";

    public override void ProcessWorld()
    {
        if (Game.HasAntiMagic || base.Game.DieRoll(9000) != 1)
        {
            return;
        }
        Game.Disturb(false);
        Game.MsgPrint("Magical energy flows through you! You must release it!");
        Game.MsgPrint(string.Empty);

        // Get a direction.  We do not care if the player cancels the direction, we will release the energy anyway.
        Game.GetDirectionWithAim(out int direction);
        Projectile projectile = Game.SingletonRepository.Get<Projectile>(nameof(ManaProjectile));
        projectile.TargetedFire(direction, Game.ExperienceLevel.IntValue * 2, 3, grid: true, item: true, kill: true, jump: false, beam: false, thru: true, hide: false, stop: true);
    }
}