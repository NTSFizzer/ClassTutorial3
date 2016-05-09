using Gallery3Winform;
using Gallery3WinForm.ServiceReference1;
using System;
using System.Windows.Forms;

namespace Gallery3WinForm
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        ///

        public static Service1Client SvcClient = new Service1Client();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            clsPainting.LoadPaintingForm = new clsPainting.LoadPaintingFormDelegate(frmPainting.Run);
            clsPhotograph.LoadPhotographForm = new clsPhotograph.LoadPhotographFormDelegate(frmPhotograph.Run);
            clsSculpture.LoadSculptureForm = new clsSculpture.LoadSculptureFormDelegate(frmSculpture.Run);
            Application.Run(frmMain.Instance);
            if (SvcClient != null && SvcClient.State != System.ServiceModel.CommunicationState.Closed) SvcClient.Close();
        }
    }
}
