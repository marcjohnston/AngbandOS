// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations;

[Serializable]
internal abstract class Mutation : IGetKey<string>
{
    protected readonly SaveGame SaveGame;
    protected Mutation(SaveGame saveGame)
    {
        SaveGame = saveGame;
    }
    public virtual string Key => GetType().Name;

    public string GetKey => Key;
    public void Bind() { }

    public virtual string AttackDescription => "";
    public virtual int DamageDiceNumber => 0;
    public virtual int DamageDiceSize => 0;
    public virtual int EquivalentWeaponWeight => 0;
    public abstract int Frequency { get; }
    public abstract string GainMessage { get; }
    public virtual MutationGroup Group => MutationGroup.None;
    public abstract string HaveMessage { get; }
    public abstract string LoseMessage { get; }
    public virtual MutationAttackType MutationAttackType => MutationAttackType.Physical;

    public virtual void Activate() { }

    public virtual string ActivationSummary(int lvl)
    {
        return string.Empty;
    }

    public virtual void OnGain(Genome genome) { }

    public virtual void OnLose(Genome genome) { }

    public virtual void OnProcessWorld() { }
}