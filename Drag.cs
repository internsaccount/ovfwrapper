using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI_OVFTOOL
{
    class Drag
    {
        //Function for drag and drop the file in the application
        public String drop(DragEventArgs e)
        {
            try
            {
                String file1 = "", file2 = "";
                String[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                foreach (string file in files)
                {
                    file2 = file;
                    file1 = file.Substring(file.Length - 4, 4);
                }
                if (file1 == ".ovf" || file1 == ".ova" || file1==".iso" || file1==".vmx")
                {
                    return file2;
                }
                else
                {
                    return "Error";
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                return null;
            }
        }
    }
}
