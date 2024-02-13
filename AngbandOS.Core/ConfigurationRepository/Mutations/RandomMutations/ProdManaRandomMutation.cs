// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class ProdManaRandomMutation : Mutation
{
    private ProdManaRandomMutation(SaveGame saveGame) : base(saveGame) { }
    public override int Frequency => 1;
    public override string GainMessage => "You start producing magical energy uncontrollably.";
    public override string HaveMessage => "You are producing magical energy uncontrollably.";
    public override string LoseMessage => "You stop producing magical energy uncontrollably.";

    public override void OnProcessWorld()
    {
        if (SaveGame.HasAntiMagic || base.SaveGame.DieRoll(9000) != 1)
        {
            return;
        }
        SaveGame.Disturb(false);
        SaveGame.MsgPrint("Magical energy flows through you! You must release it!");
        SaveGame.MsgPrint(null);
        SaveGame.GetDirectionNoAutoAim(out int dire);
        SaveGame.FireBall(SaveGame.SingletonRepository.Projectiles.Get(nameof(ManaProjectile)), dire, SaveGame.ExperienceLevel * 2, 3);
    }
}