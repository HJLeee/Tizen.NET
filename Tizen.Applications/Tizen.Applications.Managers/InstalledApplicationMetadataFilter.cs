/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;

namespace Tizen.Applications.Managers
{
    /// <summary>
    /// InstalledApplicationMetadataFilter class. This class is a parameter of InstallerApplicationAppsAsync method.
    /// </summary>
    public class InstalledApplicationMetadataFilter : IDisposable
    {
        private IntPtr _handle;
        private bool disposed = false;

        private const string LogTag = "Tizen.Applications.Managers";
        private int ret = 0;

        public InstalledApplicationMetadataFilter(IDictionary<string, string> filter)
        {
            ret = Interop.ApplicationManager.AppInfoMetadataFilterCreate(out _handle);
            if (ret != 0)
            {
                ApplicationManagerErrorFactory.ExceptionChecker(ret, _handle, "InstalledApplicationMetadataFilter creation failed.");
            }
            foreach (var item in filter)
            {
                ret = Interop.ApplicationManager.AppInfoMetadataFilterAdd(_handle, item.Key, item.Value);
                if (ret != 0)
                {
                    ApplicationManagerErrorFactory.ExceptionChecker(ret, _handle, "InstalledApplicationMetadataFilter item add failed.");
                }
            }
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
        }

        ~InstalledApplicationMetadataFilter()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                // to be used if there are any other disposable objects
            }
            if (_handle != IntPtr.Zero)
            {
                Interop.ApplicationManager.AppInfoMetadataFilterDestroy(_handle);
            }
            disposed = true;
        }
    }
}
