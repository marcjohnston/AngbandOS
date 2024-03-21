// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations.RandomMutations;

[Serializable]
internal class TrunkRandomMutation : Mutation
{
    private TrunkRandomMutation(Game game) : base(game) { }
    public override int Frequency => 2;
    public override string GainMessage => "Your nose grows into an elephant-like trunk.";
    public override string HaveMessage => "You have an elephantine trunk (dam 1d4).";
    public override string LoseMessage => "Your nose returns to a normal length.";
    public override MutationGroup Group => MutationGroup.Mouth;
    public override int DamageDiceSize => 1;
    public override int DamageDiceNumber => 4;
    public override int EquivalentWeaponWeight => 35;
    public override string AttackDescription => "trunk";

    public override void OnGain()
    {
        Game.NaturalAttacks.Add(this);
    }

    public override void OnLose()
    {
        Game.NaturalAttacks.Remove(this);
    }
}