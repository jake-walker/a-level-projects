using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sieve_of_Eratosthenes
{
    using System.Windows.Media;

    class ColourList
    {
        public static List<Brush> Brushes = new List<Brush>()
                                         {
                                             new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)0, (byte)0)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)127, (byte)0)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)255, (byte)0)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)127, (byte)255, (byte)0)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)0, (byte)255, (byte)0)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)0, (byte)255, (byte)127)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)0, (byte)255, (byte)255)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)0, (byte)127, (byte)255)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)0, (byte)0, (byte)255)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)127, (byte)0, (byte)255)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)0, (byte)255)),
                                             new SolidColorBrush(Color.FromArgb(255, (byte)255, (byte)0, (byte)127)),
                                         };
    }
}
