using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;

namespace CreateManifest
{
    /// <summary>
    /// Interaction logic for RedistributionMaker.xaml
    /// </summary>
    public partial class RedistributionMaker: Window
    {
        public RedistributionMaker()
        {
            InitializeComponent();
        }

        string MAJA = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\AJA\";
        string MBLUEFISH = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\BlueFish\";
        string MDELTA = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\DELTACAST\";
        string MMAGE = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Magewell\";
        string MFOVERLAYHTML = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\MFOverlayHTML\";
        string MNDI = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\NDI\";
        string MSL = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\StreamLabs\";

        string MDELAY = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Plugin.Delay.x64.dll";

        string MCHROMAKEY = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Plugin.CK.x64.dll";

        string MCCDISPLAY = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Plugin.CC.x64.dll";

        string MCOLORS = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Plugin.Colors.x64.dll";

        string MDTMF = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Plugin.DTMF.x64.dll";

        string MWEBRTC = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.WebRTC.x64.dll";

        string MFWEBCAMS = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Device.DS.x64.dll";

        string MFWEBCAPTURE = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Device.HTML.x64.dll";

        string MFSCREEN = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Device.SCR.x64.dll";

        string MFILE = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.File.x64.dll";

        string MLIVE = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Live.x64.dll";

        string MMIXER = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Mixer.x64.dll";

        string MPLAYLIST = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Playlist.x64.dll";

        string MPREVIEW = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Preview.x64.dll";

        string MRENDERER = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Renderer.x64.dll";

        string MWRITER = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Writer.x64.dll";

        string MCHARGEN = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Plugin.CG.x64.dll";

        string DECODERS = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\DecoderLib\";

        string ENCODERS = @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\EncoderLib\";

        List<string> COMMON_FILES = new List<string>
        {
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Platform.x64.dll",
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\MLProxy.dll",
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\MServer.exe",
            @"c:\Program Files (x86)\Medialooks\Medialooks Common\x64\D3DCompiler_43.dll",
            @"c:\Program Files (x86)\Medialooks\Medialooks Common\x64\d3dcompiler_47.dll",
            @"c:\Program Files (x86)\Medialooks\Medialooks Common\x64\Medialooks.Runtime.x64.dll",
            @"c:\Program Files (x86)\Medialooks\Medialooks Common\x64\MServer.exe",
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\glew32.dll",

            //mp_InstallerChanges
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Codecs.Core.x64.dll",            
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Codecs.GPU.x64.dll",
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\Medialooks.Codecs.SRT.x64.dll",
            @"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\SRT.LICENSE.txt"
        };



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cbox_x64.IsChecked == false && cbox_x86.IsChecked == false)
            {
                System.Windows.MessageBox.Show("Choose a build configuration first", "Redistribution Error", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            string outputDir = tbOutputFolder.Text;
            if (string.IsNullOrEmpty(outputDir))
            {

                FolderBrowserDialog fBrowser = new FolderBrowserDialog();
                if (fBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    outputDir = fBrowser.SelectedPath;
                }
                else
                    return;
            }
            if (!Directory.Exists(outputDir))
            {
                System.Windows.MessageBox.Show("There is no such output directory!" + Environment.NewLine + "Please choose another folder.", "Redistribution Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            
            string saveDirx64 = outputDir + "\\x64";
            string saveDirx86 = outputDir + "\\x86";
            if (cbox_x64.IsChecked == true)
            {
                // prepare x64 package
                ClearFolder(saveDirx64);
                CreatePackage(saveDirx64, true);
            }

            if (cbox_x86.IsChecked == true)
            {
                // prepare x86 package
                ClearFolder(saveDirx86);
                CreatePackage(saveDirx86, false);
            }
            SaveSettings();
            System.Windows.MessageBox.Show("Redistribution package is ready!", "Success", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }


        private void Window_Loaded(object sender, RoutedEventArgs e) => LoadSettings();

        private void ClearFolder(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists) return;
            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }


        }
        private string ConvertStringX86X64(string input, bool is64)
        {
            return is64 ? input : input.Replace("x64", "x86");
        }
        private void CreatePackage(string targetDir, bool is64)
        {
            try
            {
                System.IO.Directory.CreateDirectory(targetDir);
            }
            catch
            {
                System.Windows.MessageBox.Show("Can't create an output folder for redistribution!", "Redistribution Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (string commonFile in COMMON_FILES)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(commonFile, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(commonFile, is64), destFile, true);
            }

            if (cbox_MFile.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFILE, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MFILE, is64), destFile, true);
                DirectoryCopy(ConvertStringX86X64(DECODERS, is64), targetDir);
            }

            if (cbox_MWriter.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MWRITER, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MWRITER, is64), destFile, true);
                DirectoryCopy(ConvertStringX86X64(ENCODERS, is64), targetDir);
            }

            if (cbox_MLive.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MLIVE, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MLIVE, is64), destFile, true);

                if (cbox_MScreen.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFSCREEN, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFSCREEN, is64), destFile, true);
                }
                if (cbox_MWebCapture.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFWEBCAPTURE, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFWEBCAPTURE, is64), destFile, true);
                }

                if (cbox_MNDI.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MNDI, is64) , targetDir);
                }
                if (cbox_MSL.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MSL, is64), targetDir);
                }
                if (cbox_MWebcameras.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFWEBCAMS, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFWEBCAMS, is64), destFile, true);
                }
                if (cbox_MBMD.IsChecked == true)
                {
                    // for the moment, BMD is in MFDevice_I. Later there will be a separated DLL
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFWEBCAMS, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFWEBCAMS, is64), destFile, true);
                }
                if (cbox_MAJA.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MAJA, is64), targetDir);
                }
                if (cbox_MBF.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MBLUEFISH, is64), targetDir);
                }
                if (cbox_MDelta.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MDELTA, is64), targetDir);
                }
                if (cbox_MMage.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MMAGE, is64), targetDir);
                }

                if (cbox_MWebRTC.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MWEBRTC, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MWEBRTC, is64), destFile, true);
                }
            }

            if (cbox_MRenderer.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MRENDERER, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MRENDERER, is64), destFile, true);

                if (cbox_MScreen.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFSCREEN, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFSCREEN, is64), destFile, true);
                }
                if (cbox_MWebCapture.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFWEBCAPTURE, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFWEBCAPTURE, is64), destFile, true);
                }

                if (cbox_MNDI.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MNDI, is64), targetDir);
                }
                if (cbox_MSL.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MSL, is64), targetDir);
                }
                if (cbox_MBMD.IsChecked == true)
                {
                    // for the moment, BMD is in MFDevice_I. Later there will be a separated DLL
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MFWEBCAMS, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MFWEBCAMS, is64), destFile, true);
                }
                if (cbox_MAJA.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MAJA, is64), targetDir);
                }
                if (cbox_MBF.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MBLUEFISH, is64), targetDir);
                }
                if (cbox_MDelta.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MDELTA, is64), targetDir);
                }
                if (cbox_MMage.IsChecked == true)
                {
                    DirectoryCopy(ConvertStringX86X64(MMAGE, is64), targetDir);
                }

                if (cbox_MWebRTC.IsChecked == true)
                {
                    fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MWEBRTC, is64));
                    destFile = System.IO.Path.Combine(targetDir, fileName);
                    System.IO.File.Copy(ConvertStringX86X64(MWEBRTC, is64), destFile, true);
                }
            }

            if (cbox_MPreview.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MPREVIEW, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MPREVIEW, is64), destFile, true);
            }

            if (cbox_Mixer.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MMIXER, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MMIXER, is64), destFile, true);
                DirectoryCopy(ConvertStringX86X64(DECODERS, is64), targetDir);
            }

            if (cbox_Playlist.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MPLAYLIST, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MPLAYLIST, is64), destFile, true);
                DirectoryCopy(ConvertStringX86X64(DECODERS, is64), targetDir);
            }

            if (cbox_MHTML5.IsChecked == true)
            {
                DirectoryCopy(ConvertStringX86X64(MFOVERLAYHTML, is64), targetDir);
            }

            if (cbox_MChromaKey.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MCHROMAKEY, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MCHROMAKEY, is64), destFile, true);
            }

            if (cbox_MCCDisplay.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MCCDISPLAY, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MCCDISPLAY, is64), destFile, true);
            }

            if (cbox_MDelay.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MDELAY, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MDELAY, is64), destFile, true);
            }

            if (cbox_MColors.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MCOLORS, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MCOLORS, is64), destFile, true);
            }

            if (cbox_MCharGen.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MCHARGEN, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MCHARGEN, is64), destFile, true);
            }

            if (cbox_MFDTMF.IsChecked == true)
            {
                string fileName = System.IO.Path.GetFileName(ConvertStringX86X64(MDTMF, is64));
                string destFile = System.IO.Path.Combine(targetDir, fileName);
                System.IO.File.Copy(ConvertStringX86X64(MDTMF, is64), destFile, true);
            }
        }

        void DirectoryCopy(string sourceDir, string targetDir)
        {
            Directory.CreateDirectory(targetDir);
            if (!Directory.Exists(sourceDir)) return;
            foreach (var file in Directory.GetFiles(sourceDir))
                File.Copy(file, System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(file)), true);

            foreach (var directory in Directory.GetDirectories(sourceDir))
                DirectoryCopy(directory, System.IO.Path.Combine(targetDir, System.IO.Path.GetFileName(directory)));
        }
       
        private void SaveSettings()
        {
            Properties.Settings.Default.x86 = cbox_x86.IsChecked == true;
            Properties.Settings.Default.x64 = cbox_x64.IsChecked == true;
            Properties.Settings.Default.MFile = cbox_MFile.IsChecked == true;
            Properties.Settings.Default.MWriter = cbox_MWriter.IsChecked == true;
            Properties.Settings.Default.MLive = cbox_MLive.IsChecked == true;
            Properties.Settings.Default.MRenderer = cbox_MRenderer.IsChecked == true;
            Properties.Settings.Default.MPreview = cbox_MPreview.IsChecked == true;
            Properties.Settings.Default.MWebRTC = cbox_MWebRTC.IsChecked == true;
            Properties.Settings.Default.MScreen = cbox_MScreen.IsChecked == true;
            Properties.Settings.Default.MWebCapture = cbox_MWebCapture.IsChecked == true;
            Properties.Settings.Default.MWebcameras = cbox_MWebcameras.IsChecked == true;
            Properties.Settings.Default.MNDI = cbox_MNDI.IsChecked == true;
            Properties.Settings.Default.MSL = cbox_MSL.IsChecked == true;
            Properties.Settings.Default.MBMD = cbox_MBMD.IsChecked == true;
            Properties.Settings.Default.MAJA = cbox_MAJA.IsChecked == true;
            Properties.Settings.Default.MBF = cbox_MBF.IsChecked == true;
            Properties.Settings.Default.MDelta = cbox_MDelta.IsChecked == true;
            Properties.Settings.Default.MMage = cbox_MMage.IsChecked == true;
            Properties.Settings.Default.MHTML5 = cbox_MHTML5.IsChecked == true;
            Properties.Settings.Default.MChromaKey = cbox_MChromaKey.IsChecked == true;
            Properties.Settings.Default.MCCDisplay = cbox_MCCDisplay.IsChecked == true;
            Properties.Settings.Default.MDelay = cbox_MDelay.IsChecked == true;
            Properties.Settings.Default.MColors = cbox_MColors.IsChecked == true;
            Properties.Settings.Default.MCharGen = cbox_MCharGen.IsChecked == true;
            Properties.Settings.Default.MFDTMF = cbox_MFDTMF.IsChecked == true;
            Properties.Settings.Default.MMixer = cbox_Mixer.IsChecked == true;
            Properties.Settings.Default.MPlaylist = cbox_Playlist.IsChecked == true;
            Properties.Settings.Default.Save();
        }

        private void LoadSettings()
        {
            cbox_x86.IsChecked = Properties.Settings.Default.x86;
            cbox_x64.IsChecked = Properties.Settings.Default.x64;
            cbox_Mixer.IsChecked = Properties.Settings.Default.MMixer;
            cbox_Playlist.IsChecked = Properties.Settings.Default.MPlaylist;
            cbox_MFile.IsChecked = Properties.Settings.Default.MFile;
            cbox_MWriter.IsChecked = Properties.Settings.Default.MWriter;
            cbox_MLive.IsChecked = Properties.Settings.Default.MLive;
            cbox_MRenderer.IsChecked = Properties.Settings.Default.MRenderer;
            cbox_MPreview.IsChecked = Properties.Settings.Default.MPreview;
            cbox_MWebRTC.IsChecked = Properties.Settings.Default.MWebRTC;
            cbox_MScreen.IsChecked = Properties.Settings.Default.MScreen;
            cbox_MWebCapture.IsChecked = Properties.Settings.Default.MWebCapture;
            cbox_MWebcameras.IsChecked = Properties.Settings.Default.MWebcameras;
            cbox_MNDI.IsChecked = Properties.Settings.Default.MNDI;
            cbox_MSL.IsChecked = Properties.Settings.Default.MSL;
            cbox_MBMD.IsChecked = Properties.Settings.Default.MBMD;
            cbox_MAJA.IsChecked = Properties.Settings.Default.MAJA;
            cbox_MBF.IsChecked = Properties.Settings.Default.MBF;
            cbox_MDelta.IsChecked = Properties.Settings.Default.MDelta;
            cbox_MMage.IsChecked = Properties.Settings.Default.MMage;
            cbox_MHTML5.IsChecked = Properties.Settings.Default.MHTML5;
            cbox_MChromaKey.IsChecked = Properties.Settings.Default.MChromaKey;
            cbox_MCCDisplay.IsChecked = Properties.Settings.Default.MCCDisplay;
            cbox_MDelay.IsChecked = Properties.Settings.Default.MDelay;
            cbox_MColors.IsChecked = Properties.Settings.Default.MColors;
            cbox_MCharGen.IsChecked = Properties.Settings.Default.MCharGen;
            cbox_MFDTMF.IsChecked = Properties.Settings.Default.MFDTMF;
            EnableDevices(null, null);
            // check if x64 exists
            if (!Directory.Exists(@"c:\Program Files (x86)\Medialooks\MPlatform SDK\Bin\x64\") || !Directory.Exists(@"c:\Program Files (x86)\Medialooks\Medialooks Common\x64\"))
            {
                cbox_x64.IsChecked = false;
                cbox_x64.IsEnabled = false;
            }
            // check if it is x86 machine
            if (Directory.Exists(@"c:\Program Files\Medialooks\Medialooks Common"))
            {
                CorrectNames();
            }
            //CorrectNames();
            CheckDirectoryComponent(cbox_MAJA, MAJA);
            CheckDirectoryComponent(cbox_MBF, MBLUEFISH);
            CheckDirectoryComponent(cbox_MDelta, MDELTA);
            CheckDirectoryComponent(cbox_MHTML5, MFOVERLAYHTML);
            CheckDirectoryComponent(cbox_MMage, MMAGE);
            CheckDirectoryComponent(cbox_MNDI, MNDI);
            CheckDirectoryComponent(cbox_MSL, MSL);
        }

        private void CorrectNames()
        {
            MAJA = MAJA.Replace(@" (x86)", "");
            MBLUEFISH = MBLUEFISH.Replace(@" (x86)", ""); ;
            MDELTA = MDELTA.Replace(@" (x86)", ""); ;
            MMAGE = MMAGE.Replace(@" (x86)", ""); ;
            MFOVERLAYHTML = MFOVERLAYHTML.Replace(@" (x86)", ""); ;
            MNDI = MNDI.Replace(@" (x86)", ""); ;
            MSL = MSL.Replace(@" (x86)", ""); ;
            MDELAY = MDELAY.Replace(@" (x86)", ""); ;
            MDTMF = MDTMF.Replace(@" (x86)", ""); ;
            MWEBRTC = MWEBRTC.Replace(@" (x86)", "");
            MFWEBCAMS = MFWEBCAMS.Replace(@" (x86)", "");
            MFILE = MFILE.Replace(@" (x86)", "");
            MLIVE = MLIVE.Replace(@" (x86)", "");
            MMIXER = MMIXER.Replace(@" (x86)", "");
            MPLAYLIST = MPLAYLIST.Replace(@" (x86)", "");
            MPREVIEW = MPREVIEW.Replace(@" (x86)", "");
            MRENDERER = MRENDERER.Replace(@" (x86)", "");
            MWRITER = MWRITER.Replace(@" (x86)", "");
            DECODERS = DECODERS.Replace(@" (x86)", "");
            ENCODERS = ENCODERS.Replace(@" (x86)", "");
            MFWEBCAPTURE = MFWEBCAPTURE.Replace(@" (x86)", ""); 
            MFSCREEN = MFSCREEN.Replace(@" (x86)", ""); 
            MCHARGEN = MCHARGEN.Replace(@" (x86)", ""); 
            MCHROMAKEY = MCHROMAKEY.Replace(@" (x86)", ""); 
            MCCDISPLAY = MCCDISPLAY.Replace(@" (x86)", "");
            MCOLORS = MCOLORS.Replace(@" (x86)", "");
            var newList = COMMON_FILES.Select(s => s.Replace(@" (x86)", "")).ToList();
            COMMON_FILES = newList;

        }

        private void CheckDirectoryComponent(System.Windows.Controls.CheckBox cBox, string path)
        {
            if (!Directory.Exists(path) && !Directory.Exists(ConvertStringX86X64(path, false)))
            {
                cBox.IsChecked = false;
                cBox.IsEnabled = false;
            }
        }

        private void DisableDevices(object sender, RoutedEventArgs e)
        {
            groupDevices.IsEnabled = cbox_MLive.IsChecked == true || cbox_MRenderer.IsChecked == true;
        }

        private void EnableDevices(object sender, RoutedEventArgs e)
        {
            groupDevices.IsEnabled = cbox_MLive.IsChecked == true || cbox_MRenderer.IsChecked == true;
        }

        private void ChooseOutputFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fBrowser = new FolderBrowserDialog();
            if (fBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tbOutputFolder.Text = fBrowser.SelectedPath;
            }
        }       

        private void DT_btn_Click(object sender, RoutedEventArgs e)
        {
            cbox_x64.IsChecked = true;
            cbox_x86.IsChecked = true;

            cbox_Playlist.IsChecked = true;            
            cbox_MPreview.IsChecked = true;
            cbox_MWriter.IsChecked = true;
            cbox_MRenderer.IsChecked = true;

            cbox_MBMD.IsChecked = true;
            cbox_MAJA.IsChecked = true;            
            cbox_MNDI.IsChecked = true;
            cbox_MWebcameras.IsChecked = true;
            cbox_MScreen.IsChecked = true;
            cbox_MSL.IsChecked = true;
            cbox_MBF.IsChecked = true;
            cbox_MDelta.IsChecked = true;
            cbox_MMage.IsChecked = true;

            cbox_MCCDisplay.IsChecked = true;
            cbox_MDelay.IsChecked = true;
            cbox_MColors.IsChecked = true;
            cbox_MCharGen.IsChecked = true;
        }
    }
}
