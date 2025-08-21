// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal abstract class Mutation : IGetKey
{
    protected readonly Game Game;
    protected Mutation(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;

    /// <summary>
    /// Returns the entity serialized into a Json string.
    /// </summary>
    /// <returns></returns>

    public string GetKey => Key;
    public void Bind()
    {
        // Check to see if there is an activation that needs binding.
        if (ActivationBinding is not null)
        {
            IScript activationScript = Game.SingletonRepository.Get<IScript>(ActivationBinding.Value.ActivationScriptBindingKey);
            Ability ability = Game.SingletonRepository.Get<Ability>(ActivationBinding.Value.AbilityBindingKey);
            Expression costExpression = Game.ParseNumericExpression(ActivationBinding.Value.CostExpression);
            Activation = (activationScript, ActivationBinding.Value.MinLevel, costExpression, ability, ActivationBinding.Value.Difficulty);
        }
    }
    private (IScript ActivationScript, int MinLevel, Expression Cost, Ability Ability, int Difficulty)? Activation;
    protected virtual (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding { get; } = null;

    public virtual string AttackDescription => "";
    public virtual int DamageDiceNumber => 0;
    public virtual int DamageDiceSize => 0;
    public virtual int EquivalentWeaponWeight => 0;
    public abstract int Frequency { get; }
    public abstract string GainMessage { get; }
    public virtual MutationGroupEnum Group => MutationGroupEnum.None;
    public abstract string HaveMessage { get; }
    public abstract string LoseMessage { get; }
    public virtual MutationAttackTypeEnum MutationAttackType => MutationAttackTypeEnum.Physical;

    public void Activate()
    {
        if (Activation is not null)
        {
            int cost = Game.ComputeIntegerExpression(Activation.Value.Cost).Value;
            if (Game.CheckIfRacialPowerWorks(Activation.Value.MinLevel, cost, Activation.Value.Ability, Activation.Value.Difficulty))
            {
                Activation.Value.ActivationScript.ExecuteScript();
            }
        }
    }

    public virtual string ActivationSummary(int lvl)
    {
        return string.Empty;
    }

    public virtual void OnGain() { }

    public virtual void OnLose() { }

    public virtual void ProcessWorld() { }
}