﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core.ProjectileGraphics;

[Serializable]
internal class GenericProjectileGraphic : ProjectileGraphic
{
    public GenericProjectileGraphic(Game game, ProjectileGraphicDefinition projectileGraphicDefinition) : base(game)
    {
        Key = projectileGraphicDefinition.Key;
        Character = projectileGraphicDefinition.Character;
        Color = projectileGraphicDefinition.Color;
    }

    public override string Key { get; }

    /// <summary>
    /// Returns the character to be used for the projectile.
    /// </summary>
    public override char Character { get;  }

    /// <summary>
    /// Returns the color to be used for the projectile.
    /// </summary>
    public override ColorEnum Color { get; } = ColorEnum.White;
}