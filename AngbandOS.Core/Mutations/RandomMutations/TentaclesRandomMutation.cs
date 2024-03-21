// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class TentaclesRandomMutation : Mutation
{
    private TentaclesRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "Evil-looking tentacles sprout from your sides.";
    public override string HaveMessage => "You have evil looking tentacles (dam 2d5).";
    public override string LoseMessage => "Your tentacles vanish from your sides.";
    public override int DamageDiceSize => 2;
    public override int DamageDiceNumber => 5;
    public override int EquivalentWeaponWeight => 5;
    public override string AttackDescription => "tentacles";
    public override MutationAttackType MutationAttackType => MutationAttackType.Hellfire;

    public override void OnGain()
    {
        Game.NaturalAttacks.Add(this);
    }

    public override void OnLose()
    {
        Game.NaturalAttacks.Remove(this);
    }
}