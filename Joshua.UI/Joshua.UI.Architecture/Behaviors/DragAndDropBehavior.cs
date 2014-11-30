using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media.TextFormatting;
using Joshua.UI.Architecture.Controls;

namespace Joshua.UI.Architecture.Behaviors
{
    public class DragAndDropBehavior:Behavior<FrameworkElement>
    {
        public static readonly DependencyProperty DropCommandProperty = DependencyProperty.Register(
            "DropCommand", typeof (ICommand), typeof (DragAndDropBehavior), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty DragStartCommandProperty = DependencyProperty.Register(
            "DragStartCommand", typeof (ICommand), typeof (DragAndDropBehavior), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty DragTemplateProperty = DependencyProperty.Register(
            "DragTemplate", typeof (DataTemplate), typeof (DragAndDropBehavior), new PropertyMetadata(default(DataTemplate)));

        public DataTemplate DragTemplate
        {
            get { return (DataTemplate) GetValue(DragTemplateProperty); }
            set { SetValue(DragTemplateProperty, value); }
        }

        public ICommand DragStartCommand
        {
            get { return (ICommand) GetValue(DragStartCommandProperty); }
            set { SetValue(DragStartCommandProperty, value); }
        }


        public ICommand DropCommand
        {
            get { return (ICommand) GetValue(DropCommandProperty); }
            set { SetValue(DropCommandProperty, value); }
        }


        private DraggedAdorner draggedAdorner;

        private Point dragStartPoint;

        private DataObject dragData;

        private FrameworkElement parent;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.DragLeave+=this.on
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {
            this.
        }


        private void RemoveDraggedAdorner()
        {
            if (this.draggedAdorner != null)
            {
                
            }
        }
    }
}
