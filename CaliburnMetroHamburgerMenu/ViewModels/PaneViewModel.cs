namespace CaliburnMetroHamburgerMenu.ViewModels
{
    using System;

    using Caliburn.Micro;

    using MahApps.Metro.IconPacks;

    public class PaneViewModel : Screen, IPane
    {
        public PaneViewModel(string displayName, PackIconModernKind icon)
        {
            this.Icon = icon;
            this.DisplayName = displayName;
        }

        public PackIconModernKind Icon { get; }

        public string Log { get; private set; }

        public object Tag { get; set; }

        public void Append(string text)
        {
            this.Log += $"\r\n{DateTime.Now}: {text}";
            this.NotifyOfPropertyChange(nameof(this.Log));
        }

        protected override void OnActivate()
        {
            this.Append("OnActivate");
            base.OnActivate();
        }

        protected override void OnDeactivate(bool close)
        {
            this.Append("OnDeactivate");
            base.OnDeactivate(close);
        }
    }
}