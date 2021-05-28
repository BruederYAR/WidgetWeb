﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.IO;
using System.Text.Json;
using System.Windows.Media.Animation;

using WidgetWeb.View.Pages;
using WidgetWeb.Model;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace WidgetWeb.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        BrowserPage browserPage = new BrowserPage();
        SettingsPage settingsPage = new SettingsPage();

        private Page curretPage;
        public Page CurretPage
        {
            get { return curretPage;}
            set { curretPage = value; NotifyPropertyChanged(nameof(CurretPage)); }
        }

        private SettingsModel model = SettingsModel.Read();

        public MainWindowViewModel()
        {
            CurretPage = browserPage;
            FrameOpacity = 1;

        }
        public MainWindowViewModel(MainWindow mainWindow) : this()
        {
            if(model.HiddenUpPanel)
                mainWindow.WindowStyle = WindowStyle.None;
            else
                mainWindow.WindowStyle = WindowStyle.ToolWindow;
        }


        public void TurnPage()
        {
            if (CurretPage == browserPage)
            {
                PageAnimated(settingsPage);
            }
            else
            {
                settingsPage.viewModel.SaveSettingsCommand.Execute(null);
                browserPage.viewModel.ReadSettings();

                PageAnimated(browserPage);
            }
            NotifyPropertyChanged();
        }

        private double frameOpacity;
        public double FrameOpacity
        {
            get { return frameOpacity; }
            set { frameOpacity = value; NotifyPropertyChanged(nameof(FrameOpacity)); }
        }
        private async void PageAnimated(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for(double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(20);
                }
                CurretPage = page;
                for (double i =0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(20);
                }
            });
        }
    }
}
