namespace CaliburnMetroHamburgerMenu
{
    using System;
    using System.Windows;

    using Caliburn.Micro;

    using MahApps.Metro.Controls;

    public class MetroWindowManager : WindowManager
    {
        private ResourceDictionary[] _resourceDictionaries;

        public virtual void ConfigureWindow(MetroWindow window)
        {
        }

        public virtual MetroWindow CreateCustomWindow(object view, bool windowIsView)
        {
            MetroWindow result;
            if (windowIsView)
            {
                result = view as MetroWindow;
            }
            else
            {
                result = new MetroWindow { Content = view };
            }

            this.AddMetroResources(result);
            return result;
        }

        protected override Window EnsureWindow(object model, object view, bool isDialog)
        {
            MetroWindow window = null;
            Window inferOwnerOf;
            if (view is MetroWindow)
            {
                window = this.CreateCustomWindow(view, true);
                inferOwnerOf = this.InferOwnerOf(window);
                if (inferOwnerOf != null && isDialog)
                {
                    window.Owner = inferOwnerOf;
                }
            }

            if (window == null)
            {
                window = this.CreateCustomWindow(view, false);
            }

            this.ConfigureWindow(window);
            window.SetValue(View.IsGeneratedProperty, true);
            inferOwnerOf = this.InferOwnerOf(window);
            if (inferOwnerOf != null)
            {
                try
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    window.Owner = inferOwnerOf;
                }
                catch
                {
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                }
            }
            else
            {
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }

            if (model is IHaveDisplayName)
            {
                window.Title = (model as IHaveDisplayName).DisplayName;
            }

            return window;
        }

        private void AddMetroResources(MetroWindow window)
        {
            this._resourceDictionaries = this.LoadResources();
            foreach (ResourceDictionary dictionary in this._resourceDictionaries)
            {
                window.Resources.MergedDictionaries.Add(dictionary);
            }
        }

        private ResourceDictionary[] LoadResources()
        {
            return new[]
                       {
                           new ResourceDictionary
                               {
                                   Source = new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Colors.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source = new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Fonts.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source = new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Controls.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source = new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Controls.AnimatedSingleRowTabControl.xaml",
                                       UriKind.RelativeOrAbsolute)
                               },
                           new ResourceDictionary
                               {
                                   Source = new Uri(
                                       "pack://application:,,,/MahApps.Metro;component/Styles/Accents/Blue.xaml",
                                       UriKind.RelativeOrAbsolute)
                               }
                       };
        }
    }
}
