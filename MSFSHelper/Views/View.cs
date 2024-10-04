using Spectre.Console.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSFSHelper.Views
{
    internal abstract class View : IView
    {
        private View cachedView;

        public Renderable RenderableView 
        {
            get => BuildView();
        }
        protected abstract Renderable BuildView();
    }
}
