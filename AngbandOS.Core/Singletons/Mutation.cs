// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
using System.Runtime.CompilerServices;

namespace AngbandOS.Core;

internal abstract class Mutation : IGetKey, IGameSerialize
{
    protected Game Game { get; }
    protected Mutation(Game game)
    {
        Game = game;
    }
    public virtual string Key => GetType().Name;

    public virtual GameStateBag? Serialize(SaveGameState saveGameState) => new DictionaryGameStateBag((nameof(GainedAttributeSet), saveGameState.CreateGameStateBag(GainedAttributeSet)));

    public string GetKey => Key;
    public void Bind(RestoreGameState? restoreGameState)
    {
        ItemEnhancement = Game.SingletonRepository.GetNullable<ItemEnhancement>(ItemEnhancementBindingKey);

        // Check to see if there is an activation that needs binding.
        if (ActivationBinding is not null)
        {
            IScript activationScript = Game.SingletonRepository.Get<IScript>(ActivationBinding.Value.ActivationScriptBindingKey);
            Ability ability = Game.SingletonRepository.Get<Ability>(ActivationBinding.Value.AbilityBindingKey);
            Expression costExpression = Game.ParseNumericExpression(ActivationBinding.Value.CostExpression);
            Activation = (activationScript, ActivationBinding.Value.MinLevel, costExpression, ability, ActivationBinding.Value.Difficulty);
        }

        if (restoreGameState is not null)
        {
            RestoreGameState attributeSetRestoreGameState = restoreGameState.GetByKey(nameof(GainedAttributeSet));
            GainedAttributeSet = new ReadOnlyAttributeSet(Game, attributeSetRestoreGameState);
        }
    }
    private (IScript ActivationScript, int MinLevel, Expression Cost, Ability Ability, int Difficulty)? Activation { get; set; }
    protected virtual (string ActivationScriptBindingKey, int MinLevel, string CostExpression, string AbilityBindingKey, int Difficulty)? ActivationBinding { get; } = null;

    public virtual string AttackDescription => "";
    public virtual int DamageDiceNumber => 0;
    public virtual int DamageDiceSize => 0;
    public virtual int EquivalentWeaponWeight => 0;
    public abstract int Frequency { get; }
    public abstract string GainMessage { get; }

    /// <summary>
    /// Returns the mutation group that this mutation belongs to.  This property is used to determine which mutations can be gained together.  Mutations that belong to the same group cannot be gained together.  If a mutation does not belong to any group, this property returns <see cref="MutationGroupEnum.None"/>.
    /// </summary>
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


    /// <summary>
    /// Returns the binding key for the passive attribute enhancements that is associated with this mutation. If there are no associated passive attribute enhancements, this property returns null.  This property is used to bind the <see cref="ItemEnhacement"/> property during the binding phase.
    /// </summary>
    public virtual string? ItemEnhancementBindingKey => null;

    /// <summary>
    /// Returns the attribute enhancement object for the passive attribute enhancements that is associated with this mutation. If there are no associated passive attribute enhancements, this property returns null.  This property is bound using the <see cref="ItemEnhacementBindingKey"/> property during the binding phase.
    /// </summary>
    public ItemEnhancement? ItemEnhancement { get; private set; }

    /// <summary>
    /// Returns the attribute set that is merged with the players attribute set when this mutation is gained.  This allows the mutation attributes to remain constant for each call of the update bonuses.
    /// </summary>
    public ReadOnlyAttributeSet? GainedAttributeSet { get; set; }
}