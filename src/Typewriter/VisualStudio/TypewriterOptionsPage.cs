﻿using System;
using System.ComponentModel;
using Microsoft.VisualStudio.Shell;

namespace Typewriter.VisualStudio
{
    public class TypewriterOptionsPage : DialogPage
    {
        [Category("Rendering")]
        [DisplayName("Auto-render when C# files changes")]
        [Description("If set to True, Typewriter will track changes to the C# source files in the solution and auto-render matching TypeScript Templates (.tst).")]
        [DefaultValue(true)]
        public bool TrackSourceFiles { get; set; } = true;

        [Category("Rendering")]
        [DisplayName("Render template on save")]
        [Description("If set to True, TypeScript Templates (.tst) will be re-rendered when saved.")]
        [DefaultValue(true)]
        public bool RenderOnSave { get; set; } = true;

        [Category("Rendering")]
        [DisplayName("Add generated files to VS project")]
        [Description("If set to True, Typewriter will add generated files to Visual Studio Project.")]
        [DefaultValue(true)]
        public bool AddGeneratedFilesToProject { get; set; } = true;

        public event EventHandler OptionsChanged;

        public void Watch()
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this, new Attribute[] { DesignerSerializationVisibilityAttribute.Visible }))
            {
                property.AddValueChanged(this, (s, e) => { OptionsChanged?.Invoke(this, e); });
            }
        }
    }
}
