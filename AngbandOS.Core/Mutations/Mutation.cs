// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.Mutations;

[Serializable]
internal abstract class Mutation
{
    public string AttackDescription;
    public int DamageDiceNumber;
    public int DamageDiceSize;
    public int EquivalentWeaponWeight;
    public int Frequency;
    public string GainMessage;
    public MutationGroup Group = MutationGroup.None;
    public string HaveMessage;
    public string LoseMessage;
    public MutationAttackType MutationAttackType = MutationAttackType.Physical;

    public virtual void Activate(SaveGame saveGame)
    {
    }

    public virtual string ActivationSummary(int lvl)
    {
        return string.Empty;
    }

    public abstract void Initialize();

    public virtual void OnGain(Genome genome)
    {
    }

    public virtual void OnLose(Genome genome)
    {
    }

    public virtual void OnProcessWorld(SaveGame saveGame)
    {
    }
}