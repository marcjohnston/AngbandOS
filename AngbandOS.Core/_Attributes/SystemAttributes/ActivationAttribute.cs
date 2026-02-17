// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”
namespace AngbandOS.Core;

[Serializable]
internal class ActivationAttribute : Attribute, IGetKey
{
    private ActivationAttribute(Game game) : base(game) { }
    public override EffectiveAttributeValue CreateEffectiveAttributeValue() => new ActivationEffectiveAttributeValue(Game, this);

    public string GetKey => GetType().Name;
    public void Bind() { }
}
