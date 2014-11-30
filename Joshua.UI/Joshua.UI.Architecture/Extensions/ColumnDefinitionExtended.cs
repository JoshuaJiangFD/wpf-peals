using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Joshua.UI.Architecture.Extensions
{
    public class ColumnDefinitionExtended:ColumnDefinition
    {
        public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register(
            "Visible", typeof (Boolean), typeof (ColumnDefinitionExtended), new PropertyMetadata(default(Boolean)));

        public Boolean Visible
        {
            get { return (Boolean) GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        public ColumnDefinitionExtended()
        {
            ColumnDefinition.WidthProperty.OverrideMetadata(typeof(ColumnDefinitionExtended),
                new FrameworkPropertyMetadata(new GridLength(1, GridUnitType.Star), null, new CoerceValueCallback(CoerceWidth)));
        }

        public static void OnVisibleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            obj.CoerceValue(WidthProperty);
        }

        static object CoerceWidth(DependencyObject obj, Object value)
        {
            return (((ColumnDefinitionExtended) obj).Visible) ? value : new GridLength(0);
        }
    }
}
