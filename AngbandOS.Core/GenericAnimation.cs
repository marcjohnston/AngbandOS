// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericAnimation : Animation
{
    public GenericAnimation(Game game, AnimationGameConfiguration animationGameConfiguration) : base(game)
    {
        AlternateColor = animationGameConfiguration.AlternateColor;
        Character = animationGameConfiguration.Character;
        Color = animationGameConfiguration.Color;
        Key = animationGameConfiguration.Key ?? animationGameConfiguration.GetType().Name;
        Name = animationGameConfiguration.Name;
        Sequence = animationGameConfiguration.Sequence;
    }
    public override string Key { get; }
    public override char Character { get; }
    public override ColorEnum Color { get; }
    public override string Name { get; }
    public override ColorEnum AlternateColor { get; }
    public override string Sequence { get; }
}
