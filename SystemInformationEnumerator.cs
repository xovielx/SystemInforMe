using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Collections;
using System.Reflection;
using System.IO;

namespace SystemInforMe {
    class SystemInformationEnumerator {

        private Assembly assemblyEx;
        private string wmiLocation;

        public SystemInformationEnumerator() {
            this.assemblyEx = Assembly.GetExecutingAssembly(); // Loads the Assembly information of the process.
            this.wmiLocation = Environment.CurrentDirectory + "\\wmi.txt";
        }

        /// <summary>
        /// Displays the help dialog.
        /// </summary>
        public void displayHelpDialog() {
            Console.WriteLine("SystemInforMe.exe Help Dialog\n" +
                        "-------------------------------------\n" +
                        "Command Arguments:\n" +
                        "help - Previews this message.\n" +
                        "wmi - Displays all Win32_WMIVARIABLES.\n" +
                        "query <WMIVARIABLE> - Try to parse a custom query of the Win32WMI.\n" +
                        "1 - Displays Processor Information\n" +
                        "2 - Displays Operating System Information.\n" +
                        "3 - Displays Video Adapter Information.\n" +
                        "4 - Displays Windows Activation Information.\n" +
                        "5 - Displays BIOS Information.");
        }

        /// <summary>
        /// Unloads an Embedded wmi.txt file which includes information about the different type of query-able locations.
        /// </summary>
        private void unloadResources() {
            Stream wmiText = this.assemblyEx.GetManifestResourceStream("SystemInforMe.Resources.WMI.txt");
            FileStream wmiDrop = new FileStream(this.wmiLocation, FileMode.Create);
            wmiText.CopyTo(wmiDrop);
            wmiText.Close();
            wmiDrop.Close();
        }

        /// <summary>
        /// Reads all viable WMI paths for querying the System.
        /// </summary>
        public void displayWMIAreas() {
            unloadResources();

            StreamReader fReader = new StreamReader(wmiLocation);
            string line = "";
            while ((line = fReader.ReadLine()) != null) {
                Console.WriteLine(line);
            }
            fReader.Close();
        }

        /// <summary>
        /// Using the Systems.Management Library, queries the Windows (WMI) for information regarding the CPU.
        /// </summary>
        public void searchQuery(string win32Query) {
            try {
                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from " + win32Query);
                foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get()) {
                    foreach (PropertyData propertyData in managementBaseObject.Properties) { // Enumerates each PropertyData variable and outputs to the console.
                        try {
                            string[] strProp = { // Used to Store the Name and Value of the PropertyData for convenient Console output.
                            propertyData.Name.ToString(),
                            propertyData.Value.ToString()
                        };
                            Console.WriteLine(strProp[0] + ": " + strProp[1]);
                        } catch (Exception exc) {

                        }
                    }
                }
            } catch (Exception exc) {
                Console.WriteLine(win32Query + " is an invalid Win32WMI variable. The current query returned null.");
            }
        }

        /// <summary>
        /// Using the Systems.Management Library, queries the Windows (WMI) for information regarding the CPU.
        /// </summary>
        public void searchProcessor() {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get()) {
                foreach (PropertyData propertyData in managementBaseObject.Properties) { // Enumerates each PropertyData variable and outputs to the console.
                    try {
                        string[] strProp = { // Used to Store the Name and Value of the PropertyData for convenient Console output.
                            propertyData.Name.ToString(),
                            propertyData.Value.ToString()
                        };
                        Console.WriteLine(strProp[0] + ": " + strProp[1]);
                    } catch (Exception exc) {

                    }
                }
            }
        }

        /// <summary>
        /// Using the Systems.Management Library, queries the Windows (WMI) for information regarding the Operating System.
        /// </summary>
        public void searchOperatingSystem() {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_OperatingSystem");
            foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get()) {
                foreach (PropertyData propertyData in managementBaseObject.Properties) { // Enumerates each PropertyData variable and outputs to the console.
                    try {
                        string[] strProp = { // Used to Store the Name and Value of the PropertyData for convenient Console output.
                            propertyData.Name.ToString(),
                            propertyData.Value.ToString()
                        };
                        Console.WriteLine(strProp[0] + ": " + strProp[1]);
                    } catch (Exception exc) {

                    }
                }
            }
        }

        /// <summary>
        /// Using the Systems.Management Library, queries the Windows (WMI) for information regarding the Graphics Card.
        /// </summary>
        public void searchVideoAdapters() {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get()) {
                foreach (PropertyData propertyData in managementBaseObject.Properties) { // Enumerates each PropertyData variable and outputs to the console.
                    try {
                        string[] strProp = { // Used to Store the Name and Value of the PropertyData for convenient Console output.
                            propertyData.Name.ToString(),
                            propertyData.Value.ToString()
                        };
                        Console.WriteLine(strProp[0] + ": " + strProp[1]);
                    } catch (Exception exc) {

                    }
                }
            }
        }

        /// <summary>
        /// Using the Systems.Management Library, queries the Windows (WMI) for information regarding the Windows Activation.
        /// </summary>
        public void searchWindowsActivation() {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_WindowsProductActivation");
            foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get()) {
                foreach (PropertyData propertyData in managementBaseObject.Properties) { // Enumerates each PropertyData variable and outputs to the console.
                    try {
                        string[] strProp = { // Used to Store the Name and Value of the PropertyData for convenient Console output.
                            propertyData.Name.ToString(),
                            propertyData.Value.ToString()
                        };
                        Console.WriteLine(strProp[0] + ": " + strProp[1]);
                    } catch (Exception exc) {

                    }
                }
            }
        }

        /// <summary>
        /// Using the Systems.Management Library, queries the Windows (WMI) for information regarding the BIOS Information.
        /// </summary>
        public void searchWindowsBIOS() {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_BIOS");
            foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get()) {
                foreach (PropertyData propertyData in managementBaseObject.Properties) { // Enumerates each PropertyData variable and outputs to the console.
                    try {
                        string[] strProp = { // Used to Store the Name and Value of the PropertyData for convenient Console output.
                            propertyData.Name.ToString(),
                            propertyData.Value.ToString()
                        };
                        Console.WriteLine(strProp[0] + ": " + strProp[1]);
                    } catch (Exception exc) {

                    }
                }
            }
        }
    }
}