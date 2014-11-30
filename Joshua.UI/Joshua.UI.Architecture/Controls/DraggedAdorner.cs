using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Joshua.UI.Architecture.Controls
{
    public class DraggedAdorner:Adorner
    {
        #region Constants and Fields

        private readonly AdornerLayer adornerLayer;

        private readonly ContentPresenter contentPresenter;

        private double left;

        private double top;

        private object dragDropData;
        #endregion

        #region ctors and de-ctors
        /// <summary>
        /// Intializes a new instance of <see cref="DraggedAdorner"/> class.
        /// </summary>
        /// <param name="dragDropData"></param>
        /// <param name="dragDropTempate"></param>
        /// <param name="adornedElement"></param>
        /// <param name="adornerLayer"></param>
        public DraggedAdorner(object dragDropData,
            DataTemplate dragDropTempate, UIElement adornedElement, AdornerLayer adornerLayer):base(adornedElement)
        {
            this.adornerLayer = adornerLayer;
            this.dragDropData = dragDropData;
            this.contentPresenter=new ContentPresenter();
            this.contentPresenter.Content = dragDropData;
            this.contentPresenter.ContentTemplate = dragDropTempate;
            this.contentPresenter.Opacity = 0.8;
            this.adornerLayer.Add(this);
        }
        #endregion

        #region Properties

        public object DragDropData
        {
            get { return this.dragDropData; }
        }
        protected override int VisualChildrenCount
        {
            get { return 1; }
        }
        #endregion

        #region public methods

        public void Detach()
        {
            this.adornerLayer.Remove(this);
        }

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            var result = new GeneralTransformGroup();
            result.Children.Add(base.GetDesiredTransform(transform));
            result.Children.Add(new TranslateTransform(this.left,this.top));
            return result;
        }

        public void SetPosition(double left, double top)
        {
            //-1 and +13 align the dragged adorner with the dashed rectangle that shows up
            //near the mouse cursor when dragging.
            this.left = left - 1;
            this.top = top + 13;
            if(this.adornerLayer!=null)
                this.adornerLayer.Update(this.AdornedElement);
        }

        #endregion

        #region Methods

        protected override Size ArrangeOverride(Size finalSize)
        {
            this.contentPresenter.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.contentPresenter;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            this.contentPresenter.Measure(constraint);
            return this.contentPresenter.DesiredSize;
        }
        #endregion
    }
}
