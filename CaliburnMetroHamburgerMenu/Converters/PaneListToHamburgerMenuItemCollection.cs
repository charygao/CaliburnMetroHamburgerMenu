namespace CaliburnMetroHamburgerMenu.Converters
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Windows.Data;

    using CaliburnMetroHamburgerMenu.ViewModels;

    using MahApps.Metro.Controls;

    class PaneListToHamburgerMenuItemCollection : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var viewModels = value as ICollection<IPane>;

            var collection = new HamburgerMenuItemCollection();

            foreach (var vm in viewModels)
            {
                var item = new HamburgerMenuIconItem();
                item.Label = vm.DisplayName;
                item.Icon = vm.Icon;
                item.Tag = vm;
                vm.Tag = item;
                collection.Add(item);
            }

            return collection;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
