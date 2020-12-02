using System;
using System.Diagnostics;
using System.IO;

namespace SystemInforMe {
    /// <summary>
    /// Author: Oviel Bayola
    /// Date: 11/29/2020
    /// Description: A simple .exe command line application used for returning Console output regarding System Information queried from the WMI.
    /// </summary>
    class Program {
        static void Main(string[] args) {
            SystemInformationEnumerator systemWMIQuery = new SystemInformationEnumerator();

            string[] getCMDLine = Environment.GetCommandLineArgs(); // Grabs the command line arguments from the execution.

            string line = "";
            if (getCMDLine.Length > 1) { // If command line has one argument, store it in line.
                line = getCMDLine[1];
            }

            string lineQuery = "";
            if (getCMDLine.Length > 2) { // If command argument has two arguments, store it in lineQuery for custom WMI lookup.
                lineQuery = getCMDLine[2];
            }

            if (getCMDLine.Length > 1) {
                if (line == "help") {
                    systemWMIQuery.displayHelpDialog();
                } else if (line == "wmi") {
                    systemWMIQuery.displayWMIAreas();
                } else if (line == "query") {
                    systemWMIQuery.searchQuery(lineQuery);
                } else if (line == "1") {
                    systemWMIQuery.searchProcessor();
                } else if (line == "2") {
                    systemWMIQuery.searchOperatingSystem();
                } else if (line == "3") {
                    systemWMIQuery.searchVideoAdapters();
                } else if (line == "4") {
                    systemWMIQuery.searchWindowsActivation();
                } else if (line == "5") {
                    systemWMIQuery.searchWindowsBIOS();
                } else {
                    Console.WriteLine(line + " is not a valid command argument.\n\n");
                }
            }
        }
    }
}



