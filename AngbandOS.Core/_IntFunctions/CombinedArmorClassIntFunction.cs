
// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core.Functions;

[Serializable]
internal class CombinedArmorClassIntFunction : IChangeTracker, IGetKey, IIntValue
{
    private readonly Game Game;
    private int? OldValue = null;
    private CombinedArmorClassIntFunction(Game game)
    {
        Game = game;
    }

    public bool IsChanged => !OldValue.HasValue || OldValue.Value != Game.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() + Game.KnownBonusArmorClass;

    public string GetKey => GetType().Name;

    public int IntValue => Game.EffectiveAttributeSet.Get<SumEffectiveAttributeValue>(nameof(BaseArmorClassAttribute)).Get() + Game.KnownBonusArmorClass;

    public void Bind() {  }

    public void ClearChangedFlag()
    {
        OldValue = IntValue;
    }
}
