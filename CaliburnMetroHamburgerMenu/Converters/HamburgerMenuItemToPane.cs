namespace CaliburnMetroHamburgerMenu.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using CaliburnMetroHamburgerMenu.ViewModels;

    using MahApps.Metro.Controls;

    class HamburgerMenuItemToPane : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IPane)value)?.Tag;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((HamburgerMenuIconItem)value)?.Tag;
        }
    }
}
