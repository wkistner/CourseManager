using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CourseManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application. We are going to add a new sentence to comments.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CourseViewer());
        }
    }
}
