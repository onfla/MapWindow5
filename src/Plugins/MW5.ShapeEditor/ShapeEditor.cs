﻿using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.ShapeEditor.Menu;
using MW5.Services.Services.Abstract;

namespace MW5.Plugins.ShapeEditor
{
    [PluginExport("Shape Editor", "Sergei Leschinski", "274DCFA4-61FA-49E4-906D-E0D2E46E247B")]
    public class ShapeEditor: BasePlugin
    {
        private IAppContext _context;
        private MapListener _mapListener;
        private MenuGenerator _menuGenerator;
        private MenuListener _menuListener;
        private ProjectListener _projectListener;

        public override string Description
        {
            get { return "Provides tools for editing shapefiles and other vector formats."; }
        }

        public override void Initialize(IAppContext context)
        {
            _context = context;
            _mapListener = new MapListener(this, context);
            _menuGenerator = new MenuGenerator(context, Identity);
            _menuListener = new MenuListener(context, this);
            _projectListener = new ProjectListener(context, this);
            
        }

        public override void Terminate()
        {

        }
    }
}
