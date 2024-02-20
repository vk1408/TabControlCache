using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TabControlCache.Model;
using TabControlCache.MVVM;

namespace TabControlCache.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            for (int i = 0; i < 100; i++) 
            {
                Devices.Add(new Device(i, $"Device {i}", $"Device description {i}"));
            }
        }
        // Tab item cache to boost perfomance. No content rendering at tab switch! 
        //  Rrendering" refers to the process of generating the visual representation
        //  of elements on the screen based on their properties, styles, and layout information
        private readonly Dictionary<string, UIElement> _tabContentCache = new Dictionary<string, UIElement>();
        private object _tabItem;
        public object TabItem 
        {  
            get => _tabItem; 
            set
            {
                if (_tabItem != value) 
                { 
                    _tabItem = value;
                    OnPropertyChanged();
                    var selectedTab = value as TabItem;
                    string header = selectedTab.Header.ToString();
                    if (!_tabContentCache.ContainsKey(header))
                    {
                        // Load content for the selected TabItem
                        var content = selectedTab.Content;
                        _tabContentCache[header] = (UIElement) content;
                        selectedTab.Content = content;
                    }
                    else
                    {
                        selectedTab.Content = _tabContentCache[header];
                    }
                }
            }
        }

        private List<Device> _devices = new List<Device>();

        public List<Device> Devices
        {
            get => _devices;
            set 
            { 
                if (_devices != value) 
                { 
                    _devices = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
