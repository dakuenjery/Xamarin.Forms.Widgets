using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Widgets
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IconButton : ContentView
    {
        private static readonly Thickness DefaultIconMargin = new Thickness(1, 1, 0, 0);

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(IconButton),
                defaultValue: "", propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty TextSizeProperty =
            BindableProperty.Create(nameof(TextSize), typeof(double), typeof(IconButton),
                defaultValue: 12.0, propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(IconButton),
                defaultValue: "", propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(double), typeof(IconButton),
                defaultValue: 18.0, propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty IconMarginProperty =
            BindableProperty.Create(nameof(IconMargin), typeof(Thickness), typeof(IconButton),
                defaultValue: DefaultIconMargin, propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty ButtonStyleProperty =
            BindableProperty.Create(nameof(ButtonStyle), typeof(bool), typeof(IconButton), true);

        //public static readonly BindableProperty DirectionProperty =
        //    BindableProperty.Create(nameof(Direction), typeof(FlexDirection), typeof(IconButton),
        //        defaultValue: FlexDirection.Row, propertyChanged: OnPropertyChanged);

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(IconButton));

        public static readonly BindableProperty IconFontProperty =
            BindableProperty.Create(nameof(IconFont), typeof(string), typeof(IconButton));


        public event EventHandler Pressed;
        public event EventHandler Released;
        public event EventHandler Clicked;

        public string Text {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public double TextSize {
            get => (double)GetValue(TextSizeProperty);
            set => SetValue(TextSizeProperty, value);
        }

        public string Icon {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public double IconSize {
            get => (double)GetValue(IconSizeProperty);
            set => SetValue(IconSizeProperty, value);
        }

        public string IconFont {
            get => (string)GetValue(IconFontProperty);
            set => SetValue(IconFontProperty, value);
        }

        public Thickness IconMargin {
            get => (Thickness)GetValue(IconMarginProperty);
            set => SetValue(IconMarginProperty, value);
        }

        public bool ButtonStyle {
            get => (bool)GetValue(ButtonStyleProperty);
            set => SetValue(ButtonStyleProperty, value);
        }

        //public FlexDirection Direction {
        //    get => (FlexDirection)GetValue(DirectionProperty);
        //    set => SetValue(DirectionProperty, value);
        //}

        public ICommand Command {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }


        public IconButton()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) =>
            Clicked?.Invoke(sender, e);

        private void button_Clicked(object sender, EventArgs e) =>
            Clicked?.Invoke(sender, e);

        private void button_Pressed(object sender, EventArgs e) =>
            Pressed?.Invoke(sender, e);

        private void button_Released(object sender, EventArgs e) =>
            Released?.Invoke(sender, e);

        private void UpdateSizes()
        {
            #region hack. Xamarin.WPF cannot to Button.Padding
            if (!string.IsNullOrEmpty(Text))
            {
                var spaces = IconSize * (1.0 / 3);

                Text = $"{new string(' ', (int)spaces)}{Text.Trim()} ";
            }
            #endregion
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null && oldValue != newValue)
                (bindable as IconButton).UpdateSizes();
        }


    }
}