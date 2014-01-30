using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using Ionic.Zip;
using DiagnosticsGUI.ListViewHandler;

namespace DiagnosticsGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            statusList.View = View.Details;
            driverDownloadButton.Enabled = false;
            dotNETinstallButton.Enabled = false;
            visualRedistButton.Enabled = false;
            repairInstallationButton.Enabled = false;
            repairSKSEButton.Enabled = false;
            repairDragonButton.Enabled = false;
        }

        //insert function for columns
        public void listAddItem(string requirementData, string statusData)
        {
            statusList.Items.Add(new statusListViewHandler(new ColumnData() { Requirement = requirementData, Status = statusData }));
        }

        //Unzipping function
        private void ZipExtract(string unzipFile, string unzipLocation)
        {
            using (ZipFile thezip = ZipFile.Read(unzipFile))
            {
                foreach (ZipEntry e in thezip)
                {
                    e.Extract(unzipLocation, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }

        //File integrity scanning function
        private void ScanFiles(string skyrimPath)
        {
            

                   // Total files of mod and booleans for determining if any mods are broken
                   int TotalFiles = 13;
                   bool modBroken = false;
                   bool SKSEBroken = false;
                   bool dragonBroken = false;

                   //Define paths to mod files, excluding oblivion files and UI files
                   string d3d9_dll = String.Format(@"{0}\d3d9.dll", skyrimPath);
                   string GameAPI_dll = String.Format(@"{0}\Game.API.dll", skyrimPath);
                   string GameHook_dll = String.Format(@"{0}\Game.Hook.dll", skyrimPath);
                   string GameScript_dll = String.Format(@"{0}\Game.Script.dll", skyrimPath);
                   string GameClient_dll = String.Format(@"{0}\Modules\Game.Client.dll", skyrimPath);
                   string Lidgren_dll = String.Format(@"{0}\Lidgren.Network.dll", skyrimPath);
                   string log4net_dll = String.Format(@"{0}\log4net.dll", skyrimPath);
                   string MonoGame_dll = String.Format(@"{0}\MonoGame.Framework.dll", skyrimPath);
                   string MyGUI_dll = String.Format(@"{0}\MyGUIEngine.dll", skyrimPath);
                   string SkyrimScript_dll = String.Format(@"{0}\Skyrim.Script.dll", skyrimPath);
                   string version_dll = String.Format(@"{0}\version.dll", skyrimPath);
                   string resources_xml = String.Format(@"{0}\resources.xml", skyrimPath);

                   if (!File.Exists(d3d9_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(GameAPI_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(GameClient_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(GameHook_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(GameScript_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(Lidgren_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(log4net_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(MonoGame_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(MyGUI_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(SkyrimScript_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(version_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }
                   if (!File.Exists(resources_xml))
                   {
                       TotalFiles = TotalFiles - 1;
                       modBroken = true;
                   }


                   //Check file integrity of SKSE
                   //Define paths to SKSE files
                   string SKSELoader_exe = String.Format(@"{0}\skse_loader.exe", skyrimPath);
                   if (!File.Exists(SKSELoader_exe))
                   {
                       TotalFiles = TotalFiles - 1;
                       SKSEBroken = true;
                       listAddItem("SKSE: ", "SKSE is not installed.");
                   }
                   else
                   {
                       listAddItem("SKSE: ", "SKSE is installed.");
                   }


                   //Check file integrity of ScriptDragon
                   //Define paths to SD files

                   string dragon_dll = String.Format(@"{0}\ScriptDragon.dll", skyrimPath);

                   if (!File.Exists(dragon_dll))
                   {
                       TotalFiles = TotalFiles - 1;
                       dragonBroken = true;
                       listAddItem("ScriptDragon: ", "ScriptDragon not installed.");
                   }
                   else
                   {
                       listAddItem("ScriptDragon: ", "ScriptDragon is installed.");
                   }

                   //Create entry
                   //if (TotalFiles > 22)
                   if (TotalFiles < 13)
                   {
                       string modString = "";
                       string dragonString = "";
                       string SKSEString = "";

                       if (modBroken == true)
                       {
                           modString = "Skyrim Online";
                           repairInstallationButton.Enabled = true;
                       }
                       if (dragonBroken == true)
                       {
                           dragonString = "ScriptDragon";
                           repairDragonButton.Enabled = true;
                       }
                       if (SKSEBroken == true)
                       {
                           SKSEString = "SKSE";
                           repairSKSEButton.Enabled = true;
                       }

                       string affectedMods = String.Format("{0} {1} {2}", modString, dragonString, SKSEString);

                       //calc number of OK files
                       int nFiles = 13 - TotalFiles;
                       string OKFiles = nFiles.ToString();

                       string filesMissing = String.Format("Integrity check failed. Files missing: {0}. Affected mods: {1}", OKFiles, affectedMods);
                       listAddItem("Mod Integrity: ", filesMissing);
                   }
                   else
                   {
                       listAddItem("Mod Integrity: ", "No files missing.");
                   }
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            //Clear items before each scan
            statusList.Items.Clear();

            //Check if .NET 4.5 or 4.5.1 is installed
            //Open basekey localmachine in 32-bit registry, then open subkey NET setup.
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                if (ndpKey == null)
                {
                    listAddItem(".NET Status: ", "No supported version of .NET found!");
                    dotNETinstallButton.Enabled = true;
                }
                else
                {
                    int releaseKey = (int)ndpKey.GetValue("Release");
                    {
                        // .NET 4.5 release data
                        if (releaseKey == 378389)
                        {
                            listAddItem(".NET Status: ", ".NET 4.5 is installed.");
                        }
                        // .NET 4.5.1 release data
                        if (releaseKey == 378758)
                        {
                            listAddItem(".NET Status: ", ".NET 4.5.1 is installed.");
                        }
                        // No supported version found
                        else
                        {
                            listAddItem(".NET Status: ", "No supported version of .NET found!");
                            dotNETinstallButton.Enabled = true;
                        }
                    }
                }
            }

            //Check if NVIDIA drivers are the proper version
           using (RegistryKey driver_ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
                RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\{B2FE1952-0186-46C3-BAEC-A80AA35AC5B8}_Display.Driver"))
            {
                if (driver_ndpKey == null)
                {
                    listAddItem("GPU Driver Status: ", "No NVIDIA drivers found. You may be using an ATI card, which is unsupported by this tool.");
                }
                else
                {
                    string driverKey = (string)driver_ndpKey.GetValue("DisplayVersion");
                    {
                        if (driverKey == "314.22")
                        {
                            listAddItem("GPU Driver Status: ", "NVIDIA drivers are compatible.");
                        }
                        else
                        {
                            string statusColumn = String.Format("NVIDIA drivers (version {0}) are incompatible!", driverKey);
                            listAddItem("GPU Driver Status: ", statusColumn);
                            driverDownloadButton.Enabled = true;
                        }
                    }
                }
            }

            //Check Visual Redist
           using (RegistryKey visual_ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
               RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Wow6432Node\Microsoft\DevDiv\VC\Servicing\11.0\RuntimeMinimum"))
           {
               if (visual_ndpKey == null)
               {
                   listAddItem("Visual Redist Status: ", "Visual Studio 2012 x86 Redistributable is not installed!");
                   visualRedistButton.Enabled = true;
               }
               else
               {
                   int visualKey = (int)visual_ndpKey.GetValue("Install");
                   {
                       if (visualKey == 1)
                       {
                           listAddItem("Visual Redist Status: ", "Visual Studio 2012 x86 Redistributable is installed.");
                       }
                       else
                       {
                           listAddItem("Visual Redist Status: ", "Visual Studio 2012 x86 Redistributable is not installed!");
                           visualRedistButton.Enabled = true;
                       }
                   }
               }

           }

           //Check file integrity of mod
           using (RegistryKey path_ndpkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
               RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Wow6432Node\Bethesda Softworks\Skyrim\"))
           {
               //Catch nullpointer or custom install directory
               if (path_ndpkey == null)
               {
                   MessageBox.Show("No Skyrim installation found! Please select your installation manually.", "Path error!");

                   using (FolderBrowserDialog skyrimFolder = new FolderBrowserDialog())
                   {
                       skyrimFolder.Description = "Please select your Skyrim installation folder.";
                       skyrimFolder.ShowNewFolderButton = false;
                       skyrimFolder.RootFolder = Environment.SpecialFolder.MyComputer;

                       //Select folder from treeview
                       if (skyrimFolder.ShowDialog() == DialogResult.OK)
                       {
                           string selectedFolder = skyrimFolder.SelectedPath;
                           string fileTESV = String.Format(@"{0}\TESV.exe", selectedFolder);

                           if (!File.Exists(fileTESV))
                           {
                               statusList.Items.Clear();
                               DialogResult tryAgain = MessageBox.Show("TESV.exe not found! Please try again.");
                           }
                           else
                           {
                               string skyrimPath = skyrimFolder.SelectedPath;
                               ScanFiles(skyrimPath);
                           }
                       }
                   }
               }
               else
               {
                   string skyrimPath = (string)path_ndpkey.GetValue("Installed Path");
                   ScanFiles(skyrimPath);
               }
           }
        }

        private void forumsButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://forums.skyrim-online.com/forumdisplay.php?fid=9");
        }

        private void driverDownloadButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.nvidia.com/object/win8-win7-winvista-64bit-314.22-whql-driver.html");
            MessageBox.Show("Make sure to remove the previous drivers before installing the new version. If not, problems may occur. Installing this version of the drivers should fix any renderer or 0xc0000142 errors.");
        }

        private void dotNETinstallButton_Click(object sender, EventArgs e)
        {
            WebClient webClient_dotNET = new WebClient();

            //Download to \temp and run
            string tempPath = Path.GetTempPath();
            string downloadLocationdotNET = String.Format(@"{0}\vcredist_x86.exe", tempPath);
            webClient_dotNET.DownloadFile("http://download.microsoft.com/download/B/A/4/BA4A7E71-2906-4B2D-A0E1-80CF16844F5F/dotNetFx45_Full_setup.exe", downloadLocationdotNET);
            Process.Start(downloadLocationdotNET);
        }

        private void statusList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void visualRedistButton_Click(object sender, EventArgs e)
        {
            WebClient webClient_visual = new WebClient();

            //Download to \temp and run
            string tempPath = Path.GetTempPath();
            string downloadLocationVisual = String.Format(@"{0}\vcredist_x86.exe", tempPath);
            webClient_visual.DownloadFile("http://download.microsoft.com/download/1/6/B/16B06F60-3B20-4FF2-B699-5E9B7962F9AE/VSU_4/vcredist_x86.exe", downloadLocationVisual);
            Process.Start(downloadLocationVisual);

        }

        private void repairSKSEButton_Click(object sender, EventArgs e)
        {
            //Get Skyrim path
            using (RegistryKey path_ndpkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
              RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Wow6432Node\Bethesda Softworks\Skyrim\"))
            {
                string skyrimPath = (string)path_ndpkey.GetValue("Installed Path");

                //Download to \temp and unzip
                WebClient webClient_SKSE = new WebClient();

                
                string tempPath = Path.GetTempPath();
                string downloadLocationSKSE = String.Format(@"{0}\vcredist_x86.exe", tempPath);
                webClient_SKSE.DownloadFile("http://skse.silverlock.org/download/skse_1_06_16_installer.exe", downloadLocationSKSE);
                Process.Start(downloadLocationSKSE);
            }
        }

        private void repairDragonButton_Click(object sender, EventArgs e)
        {
            //Get Skyrim path
            using (RegistryKey path_ndpkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
              RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Wow6432Node\Bethesda Softworks\Skyrim\"))
            {
                string skyrimPath = (string)path_ndpkey.GetValue("Installed Path");

                //Download to \temp and unzip
                WebClient webClient_Dragon = new WebClient();

                
                string tempPath = Path.GetTempPath();
                string downloadLocationDragon = String.Format(@"{0}\ScriptDragon.zip", tempPath);
                webClient_Dragon.DownloadFile("http://goo.gl/NBZaoZ", downloadLocationDragon);
                ZipExtract(downloadLocationDragon, skyrimPath);
                
            }
            
        }

        private void repairInstallationButton_Click(object sender, EventArgs e)
        {
            //Get Skyrim path
            using (RegistryKey path_ndpkey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine,
              RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Wow6432Node\Bethesda Softworks\Skyrim\"))
            {
                string skyrimPath = (string)path_ndpkey.GetValue("Installed Path");

                //Download to \temp and unzip
                WebClient webClient_Client = new WebClient();


                string tempPath = Path.GetTempPath();
                string downloadLocationClient = String.Format(@"{0}\Client.zip", tempPath);
                webClient_Client.DownloadFile("http://goo.gl/wstAS1", downloadLocationClient);
                ZipExtract(downloadLocationClient, skyrimPath);
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Gracefully exit application
            Application.Exit();
        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            About aboutWindow = new About();
            aboutWindow.Show();
        }
    }
}
