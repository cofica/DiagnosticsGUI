using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiagnosticsGUI;

namespace DiagnosticsGUI.ListViewHandler
{

    public class ColumnData
    {
        public string Requirement;
        public string Status;
    }

    public class statusListViewHandler : ListViewItem
    {
        private ColumnData columnData;

         public statusListViewHandler(ColumnData columnData)
         {
             this.columnData = columnData;
             Update();
         }

         public void Update()
         {
            this.SubItems.Clear();
            //First column data
            this.Text = columnData.Requirement;

            //Second column data
            this.SubItems.Add(new ListViewSubItem(this, columnData.Status));
         }
    }

}
