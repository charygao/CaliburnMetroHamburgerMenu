namespace CaliburnMetroHamburgerMenu.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;

    using MahApps.Metro.Controls;

    public class ShellViewModel : Conductor<IPane>.Collection.OneActive
    {
        public ShellViewModel(IEnumerable<IPane> pages)
        {
            this.DisplayName = "Shell!";
            this.Items.AddRange(pages);
        }

        protected override void OnViewAttached(object view, object context)
        {
            base.OnViewAttached(view, context);

            if (this.Items.Any(i => i.Tag != null))
            {
                this.ActivateLast();
            }
        }

        public bool CanActivateLast()
        {
            return this.ActiveItem != this.Items.Last();
        }

        public void ActivateLast()
        {
            this.ActivateItem(this.Items.Last());
        }
    }
}
