using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ReadingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ReadingRepository.ReadingRepository readingRepository;

        static App()
        {
            readingRepository = new ReadingRepository.ReadingRepository();
        }

        public static ReadingRepository.ReadingRepository ReadingRepository
        {
            get
            {
                return readingRepository;
            }
        }
    }
}
