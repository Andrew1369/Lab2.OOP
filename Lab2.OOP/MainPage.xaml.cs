using System.Xml;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Controls;
using System.Collections.Generic;
using System;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Storage;
using Grid = Microsoft.Maui.Controls.Grid;

namespace Lab2.OOP
{
    public partial class MainPage : ContentPage
    {
        string filePath = "";
        IParser parser = new ParserDOM();
        private List<Student> results = new List<Student>();

        public MainPage()
        {
            InitializeComponent();
            CreateFirstRow();
        }

        private async void ReadButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
                {
                    { DevicePlatform.WinUI, new[] { ".xml" } },
                    { DevicePlatform.Android, new[] { "application/xml" } },
                    { DevicePlatform.iOS, new[] { "public.xml" } },
                    { DevicePlatform.MacCatalyst, new[] { "public.xml" } }
                });

                // Відкрити провідник файлів
                var result = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Виберіть файл",
                    FileTypes = customFileType
                });

                if (result != null)
                {
                    // Виводимо шлях до вибраного файлу
                    filePath = result.FullPath;

                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка при завантаженні", ex.Message, "OK");
            }
            
        }

        private async void ExitButton_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Підтвердження", "Ви дійсно хочете вийти ? ", "Так", "Ні");
            if (answer)
            {
                System.Environment.Exit(0);
            }
        }

        private async void HelpButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Довідка", "Лабораторна робота 2. Студента Толстопятого Андрія", "OK");
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            while (grid.RowDefinitions.Count > 1)
            {
                int lastRowIndex = grid.RowDefinitions.Count - 1;
                var elementsInRow = grid.Children
                        .Where(child => grid.GetRow(child) == lastRowIndex)
                        .ToList();

                foreach (var element in elementsInRow)
                {
                    grid.Children.Remove(element);
                }
                grid.RowDefinitions.RemoveAt(lastRowIndex);

            }
        }

        private void OnParserTypeChanged(object sender, EventArgs e)
        {
            RadioButton btn = (RadioButton)sender;
            string parserType = btn.Content.ToString();

            switch (parserType)
            {
                case "DOM":
                    parser = new ParserDOM();
                    break;
                case "SAX":
                    parser = new ParserSAX();
                    break;
                case "LINQ":
                    parser = new ParserLINQ();
                    break;
            }
        }

        private void CreateFirstRow()
        {
            List<Label> rows = new List<Label>();
            rows.Add(new Label
            {
                Text = "No",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "FullName",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "Faculty",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "Department",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "Course",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "Room",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "Block",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "CheckInDate",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            rows.Add(new Label
            {
                Text = "CheckOutDate",
                FontAttributes = FontAttributes.Bold,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            });
            // Додати стовпці та підписи для стовпців
            grid.RowDefinitions.Add(new RowDefinition());
            for (int col = 0; col < rows.Count; col++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                Grid.SetRow(rows[col], 0);
                Grid.SetColumn(rows[col], col);
                grid.Children.Add(rows[col]);
            }
        }
        
        private async void SearchButton_Clicked(object sender, EventArgs e)
        {
            ClearButton_Clicked(sender, e);
            if(filePath == "")
            {
                await DisplayAlert("Помилка при пошуку", "Спочатку завантажте XML файл", "OK");
                return;
            }
            results = parser.Search(filePath);

            DisplayResults(SearchWithKeyword(AttributeInput.Text, results));
        }

        // Функція для оновлення таблиці з результатами
        public void DisplayResults(List<Student> results)
        {
            int N = 0;
            foreach (Student student in results)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                N++;
                List<Label> rows = new List<Label>();
                rows.Add(new Label
                {
                    Text = N.ToString(),
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.FullName,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.Faculty,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.Department,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.Course,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.Room,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.Block,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.CheckInDate,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });
                rows.Add(new Label
                {
                    Text = student.CheckOutDate,
                    FontAttributes = FontAttributes.Bold,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                });

                grid.RowDefinitions.Add(new RowDefinition());
                for (int col = 0; col < rows.Count; col++)
                {
                    Grid.SetRow(rows[col], N);
                    Grid.SetColumn(rows[col], col);
                    grid.Children.Add(rows[col]);
                }
            }
        }

        private List<Student> SearchWithKeyword(string keyword, List<Student> students)
        {
            if(keyword == null) return students;
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if(student.FullName.StartsWith(keyword) || student.Faculty.StartsWith(keyword) || student.Department.StartsWith(keyword) || student.Course.StartsWith(keyword) || student.Room.StartsWith(keyword) || student.Block.StartsWith(keyword) || student.CheckInDate.StartsWith(keyword) || student.CheckOutDate.StartsWith(keyword))
                {
                    result.Add(student);
                }
            }
            return result;
        }

        private async void HtmlTransformButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(filePath))
                {
                    await DisplayAlert("Помилка", "Спершу виберіть файл для перетворення", "OK");
                    return;
                }
                string xsltFilePath = "D:\\Study\\University\\OOP\\Lab2.OOP\\Lab2.OOP\\Dormitory.xsl";
                string htmlFilePath = "D:\\output.html";

                TransportHTML.TransformXmlToHtml(filePath, xsltFilePath, htmlFilePath);
                await DisplayAlert("Успіх", "HTML файл успішно збережено за шляхом, D:\\output.html!", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка при трансформації", "Невдалося тлансформувати файл", "ОК");
            }
        }
    }

}
