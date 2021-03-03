using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkCore.Utilities
{
    internal class InternetExlporer
    {
        //TODO: Not in use but keeping in the event of future ie zoom issues
        //need this class to make sure zoom is always 100% when using IE
        public static class InternetExplorerHelper
        {
            private static int m_PreviousZoomFactor = 0;

            public static void SetZoom100()
            {


                // Get DPI setting.
                RegistryKey dpiRegistryKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop\\WindowMetrics");
                int dpi = (int)dpiRegistryKey.GetValue("AppliedDPI");
                // 96 DPI / Smaller / 100%
                int zoomFactor100Percent = 100000;

                switch (dpi)
                {
                    case 120: // Medium / 125%
                        zoomFactor100Percent = 80000;
                        break;
                    case 144: // Larger / 150%
                        zoomFactor100Percent = 66667;
                        break;
                }
                // Get IE zoom.
                RegistryKey subKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Zoom\\", true);
                if (checkZoomFactorExists() == true)

                {
                    RegistryKey zoomRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Zoom", true);
                    int currentZoomFactor = (int)zoomRegistryKey.GetValue("ZoomFactor");
                    if (currentZoomFactor != zoomFactor100Percent)
                    {
                        // Set IE zoom and remember the previous value.
                        zoomRegistryKey.SetValue("ZoomFactor", zoomFactor100Percent, RegistryValueKind.DWord);
                        m_PreviousZoomFactor = currentZoomFactor;
                    }
                }
            }
            public static bool checkZoomFactorExists()
            {
                RegistryKey subKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Zoom\\", true);
                return (subKey.GetValueNames().Contains("ZoomFactor"));
            }
            public static void ResetZoom()
            {
                //not using this as it seems to make the test success flaky for next run
                if (m_PreviousZoomFactor > 0)
                {
                    // Reapply the previous value.
                    RegistryKey zoomRegistryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Zoom", true);
                    zoomRegistryKey.SetValue("ZoomFactor", m_PreviousZoomFactor, RegistryValueKind.DWord);
                }
            }
        }
    }
}

