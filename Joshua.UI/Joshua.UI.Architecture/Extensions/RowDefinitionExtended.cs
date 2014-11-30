using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Joshua.UI.Architecture.Extensions
{
    /// <summary>
    /// Extended Grid RowDefintion to support Visible property on Row
    /// </summary>
    public class RowDefinitionExtended:RowDefinition
    {
        public static readonly DependencyProperty VisibleProperty = DependencyProperty.Register(
            "Visible", typeof (Boolean), typeof (RowDefinitionExtended), new PropertyMetadata(default(Boolean)));

        public Boolean Visible
        {
            get { return (Boolean) GetValue(VisibleProperty); }
            set { SetValue(VisibleProperty, value); }
        }

        public RowDefinitionExtended()
        {
            RowDefinition.HeightProperty.OverrideMetadata(typeof(RowDefinitionExtended),
                new FrameworkPropertyMetadata(new GridLength(1,GridUnitType.Star),null,new CoerceValueCallback(CoerceHeight)));
        }

        public static void OnVisibleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            obj.CoerceValue(HeightProperty);
        }

        private static object CoerceHeight(DependencyObject obj, Object nValue)
        {
            return (((RowDefinitionExtended) obj).Visible) ? nValue : new GridLength(0);
        }
    }
}
