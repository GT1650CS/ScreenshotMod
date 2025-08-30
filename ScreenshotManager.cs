using UnityEngine;

using System;
using System.IO;

namespace ScreenshotMod
{
    public class ScreenshotManager : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F10))
            {
                TakeScreenshot();
            }
        }

        void TakeScreenshot()
        {
            try
            {
                string picturesPath;
                if ((Application.platform == RuntimePlatform.WindowsPlayer) || (Application.platform == RuntimePlatform.OSXPlayer))
                {
                    try
                    {
                        picturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                        if (string.IsNullOrEmpty(picturesPath)) throw new Exception();
                    }
                    catch { picturesPath = Application.persistentDataPath; }
                }
                else
                {
                    picturesPath = Application.persistentDataPath;
                }

                string screenshotsRoot = Path.Combine(picturesPath, "Screenshots");
                string modFolder = Path.Combine(screenshotsRoot, "SFS");

                if (!Directory.Exists(modFolder))
                    Directory.CreateDirectory(modFolder);

                string filename = $"screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
                string path = Path.Combine(modFolder, filename);

                ScreenCapture.CaptureScreenshot(path);
                Debug.Log($"[ScreenshotMod] Queued screenshot: {path}");
            }
            catch (Exception ex)
            {
                Debug.LogError($"[ScreenshotMod] Failed to save screenshot: {ex}");
            }
        }
    }
}
