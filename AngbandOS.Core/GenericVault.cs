﻿// AngbandOS: 2022 Marc Johnston
//
// This game is released under the “Angband License”, defined as: “© 1997 Ben Harrison, James E.
// Wilson, Robert A. Koeneke This software may be copied and distributed for educational, research,
// and not for profit purposes provided that this copyright and statement are included in all such
// copies. Other copyrights may also apply.”

namespace AngbandOS.Core;

[Serializable]
internal class GenericVault : Vault
{
    public GenericVault(Game game, VaultGameConfiguration vaultGameConfiguration) : base(game)
    {
        Key = vaultGameConfiguration.Key ?? vaultGameConfiguration.GetType().Name;
        Color = vaultGameConfiguration.Color;
        Name = vaultGameConfiguration.Name;
        Category = vaultGameConfiguration.Category;
        Height = vaultGameConfiguration.Height;
        Rating = vaultGameConfiguration.Rating;
        Text = vaultGameConfiguration.Text;
        Width = vaultGameConfiguration.Width;
    }

    public override string Key { get; }
    public override ColorEnum Color { get; } = ColorEnum.White;
    public override string Name { get; }
    public override int Category { get; }
    public override int Height { get; }
    public override int Rating { get; }
    public override string Text { get; }
    public override int Width { get; }
}

