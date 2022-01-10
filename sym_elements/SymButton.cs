using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sym_elements
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SymButtonWPF"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:SymButtonWPF;assembly=SymButtonWPF"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:SymButton/>
    ///
    /// </summary>
    public class SymButton : Button
    {
        static SymButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SymButton), new FrameworkPropertyMetadata(typeof(SymButton)));
        }




        public int ColumnIndex
        {
            get { return (int)GetValue(ColumnIndexProperty); }
            set { SetValue(ColumnIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColumnIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColumnIndexProperty =
            DependencyProperty.Register("ColumnIndex", typeof(int), typeof(SymButton), new PropertyMetadata(0));




        public Brush SymbolForeground
        {                            
            get { return (Brush)GetValue(SymbolForegroundProperty); }
            set { SetValue(SymbolForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SymbolForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolForegroundProperty =
            DependencyProperty.Register("SymbolForeground", typeof(Brush), typeof(SymButton), new PropertyMetadata(Brushes.White));



        public SymOption OptionCompose
        {
            get { return (SymOption)GetValue(OptionComposeProperty); }
            set { SetValue(OptionComposeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OptionCompose.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OptionComposeProperty =
            DependencyProperty.Register("OptionCompose", typeof(SymOption), typeof(SymButton), new PropertyMetadata(SymOption.TextAndSymbol, OptionChanged));

        private static void OptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var symbutton = (SymButton)d;
            var option = (SymOption)e.NewValue;
            if (option == SymOption.TextAndSymbol)
            {
                setMargin(symbutton, symbutton.Position);
            }
            else
                symbutton.SetCurrentValue(SymButton.SymMarginProperty, new Thickness(0, 0, 0, 0));
        }

        public Thickness SymMargin
        {
            get { return (Thickness)GetValue(SymMarginProperty); }
            set { SetValue(SymMarginProperty, value); }
        }

        // Using a DependencyProperty as the backing store for thickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymMarginProperty =
            DependencyProperty.Register("SymMargin", typeof(Thickness), typeof(SymButton), new PropertyMetadata(new Thickness(0,0,6,0)));


        public SymbolPosition Position
        {
            get { return (SymbolPosition)GetValue(PositionProperty); }
            set { SetValue(PositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Position.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositionProperty =
            DependencyProperty.Register("Position", typeof(SymbolPosition), typeof(SymButton), new PropertyMetadata(SymbolPosition.Left, PositionChangedCallback));

        private static void PositionChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var symbutton = (SymButton)d;
            var position = (SymbolPosition)e.NewValue;
            setMargin(symbutton, position);
        }     
        
        private static void setMargin(SymButton symbutton, SymbolPosition position)
        {
            switch (position)
            {
                case SymbolPosition.Left:
                    symbutton.SetCurrentValue(SymButton.ColumnIndexProperty, 0);
                    symbutton.SetCurrentValue(SymButton.SymMarginProperty, new Thickness(0, 0, 6, 0));
                    break;
                case SymbolPosition.Right:
                    symbutton.SetCurrentValue(SymButton.ColumnIndexProperty, 2);
                    symbutton.SetCurrentValue(SymButton.SymMarginProperty, new Thickness(6, 0, 0, 0));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public int SymFontSize
        {
            get { return (int)GetValue(SymFontSizeProperty); }
            set { SetValue(SymFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SymFontSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymFontSizeProperty =
            DependencyProperty.Register("SymFontSize", typeof(int), typeof(SymButton), new PropertyMetadata(12));



        public string Symbol
        {
            get { return (string)GetValue(SymbolProperty); }
            set { SetValue(SymbolProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Symbol.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SymbolProperty =
            DependencyProperty.Register("Symbol", typeof(string), typeof(SymButton), new PropertyMetadata(""));
    }

    public enum SymbolPosition
    {
        Left,
        Right
    }

    public enum SymOption
    {
        TextAndSymbol,
        SymbolOnly,
        TextOnly
    }
}
