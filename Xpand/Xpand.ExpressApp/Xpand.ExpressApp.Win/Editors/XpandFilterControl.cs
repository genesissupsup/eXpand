﻿using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Filtering;

namespace Xpand.ExpressApp.Win.Editors {
    public class XpandFilterControl : FilterControl {

        public event Action<BaseEdit> EditorActivated;

        protected void InvokeEditorActivated(BaseEdit baseEdit) {
            Action<BaseEdit> activated = EditorActivated;
            if (activated != null && baseEdit != null) activated(baseEdit);
        }


        protected override void OnFocusedElementChanged() {
            base.OnFocusedElementChanged();
            InvokeEditorActivated(ActiveEditor);
        }



        protected override void ShowElementMenu(ElementType type) {
            base.ShowElementMenu(type);
            InvokeEditorActivated(ActiveEditor);

        }

        protected override void OnKeyDown(KeyEventArgs e) {
            base.OnKeyDown(e);
            InvokeEditorActivated(ActiveEditor);

        }
    }

    public class FilterEditorControl : DevExpress.XtraFilterEditor.FilterEditorControl {
        protected override FilterControl CreateTreeControl(){
            return new XpandFilterControl();
        }
    }
}