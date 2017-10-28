using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KeltonAndrea.Control
{
    public class NListView : ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand", typeof(ICommand), typeof(ListView), null);

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set
            {
                SetValue(ItemTappedCommandProperty, value);
            }
        }

        public NListView(ListViewCachingStrategy strategy) : base(strategy)
        {
            Initialize();
        }

        public NListView() : this(ListViewCachingStrategy.RecycleElement)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.ItemSelected += (sender, e) =>
            {
                if (ItemTappedCommand == null)
                {
                    return;
                }

                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                {
                    ItemTappedCommand.Execute(e.SelectedItem);
                }
            };
        }
    }
}
