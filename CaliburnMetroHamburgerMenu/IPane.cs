namespace CaliburnMetroHamburgerMenu
{
    using Caliburn.Micro;

    using MahApps.Metro.IconPacks;

    public interface IPane : IHaveDisplayName, IActivate, IDeactivate
    {
        PackIconModernKind Icon { get; }

        string Log { get; }

        object Tag { get; set; }

        void Append(string text);
    }
}