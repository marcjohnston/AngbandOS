// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class MutationProdMana : Mutation
{
    public override int Frequency => 1;
    public override string GainMessage => "You start producing magical energy uncontrollably.";
    public override string HaveMessage => "You are producing magical energy uncontrollably.";
    public override string LoseMessage => "You stop producing magical energy uncontrollably.";

    public override void OnProcessWorld(SaveGame saveGame)
    {
        if (saveGame.HasAntiMagic || Program.Rng.DieRoll(9000) != 1)
        {
            return;
        }
        saveGame.Disturb(false);
        saveGame.MsgPrint("Magical energy flows through you! You must release it!");
        saveGame.MsgPrint(null);
        saveGame.GetDirectionNoAutoAim(out int dire);
        saveGame.FireBall(saveGame.SingletonRepository.Projectiles.Get<ManaProjectile>(), dire, saveGame.ExperienceLevel * 2, 3);
    }
}