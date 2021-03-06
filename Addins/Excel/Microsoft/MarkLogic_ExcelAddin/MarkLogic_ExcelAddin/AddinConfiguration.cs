﻿/*
Copyright 2009-2011 MarkLogic Corporation

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 * 
 * AddinConfiguration.cs - labels/descriptions/configurations for configurable components of Addin
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;

namespace MarkLogic_ExcelAddin
{


    class AddinConfiguration
    {
        bool debugMsg = false;
        private static AddinConfiguration instance;

        private string webUrl = "";
        private string rbnTabLbl = "";
        private string rbnBtnLbl = "";
        private string rbnGrpLbl = "";
        private string ctpTtlLbl = "";

        private string isEventsEnabled = "";
        private bool eventsEnabled = false;

        private string isPaneEnabled = "";
        private bool paneEnabled = false;

        private AddinConfiguration()
        {
            //MessageBox.Show("IN INITIALIZE");
            initializeConfig();
        }

        public static AddinConfiguration GetInstance()
        {

            if (instance == null)
            {
                instance = new AddinConfiguration();
            }

            return instance;
        }

        private void initializeConfig()
        {


            RegistryKey regKey1 = Registry.CurrentUser;
            regKey1 = regKey1.OpenSubKey(@"MarkLogicAddinConfiguration\Excel");

            if (regKey1 == null)
            {
                if (debugMsg)
                    MessageBox.Show("KEY IS  NULL");

            }
            else
            {
                if (debugMsg)
                    MessageBox.Show("KEY IS: " + regKey1.GetValue("URL"));

                webUrl = (string)regKey1.GetValue("URL");
                ctpTtlLbl = (string)regKey1.GetValue("CTPTitle");
                rbnTabLbl = (string)regKey1.GetValue("RbnTabLbl");
                rbnGrpLbl = (string)regKey1.GetValue("RbnGrpLbl");
                rbnBtnLbl = (string)regKey1.GetValue("RbnBtnLbl");
                isPaneEnabled = (string)regKey1.GetValue("CTPEnabled");
                if (isPaneEnabled.ToUpper().Equals("TRUE"))
                {
                    paneEnabled = true;
                }
                isEventsEnabled = (string)regKey1.GetValue("EventsEnabled");
                if (isEventsEnabled.ToUpper().Equals("TRUE"))
                {
                    eventsEnabled = true;
                }

            }

        }

        public string getWebURL()
        {
            // MessageBox.Show("URL: " + webUrl);

            return webUrl;
        }

        public string getRibbonTabLabel()
        {
            return rbnTabLbl;
        }

        public string getRibbonGroupLabel()
        {
            return rbnGrpLbl;
        }

        public string getRibbonButtonLabel()
        {
            return rbnBtnLbl;
        }

        public string getCTPTitleLabel()
        {
            return ctpTtlLbl;
        }

        public bool getPaneEnabled()
        {
            return paneEnabled;
        }

        public bool getEventsEnabled()
        {
            return eventsEnabled;
        }
    }





}