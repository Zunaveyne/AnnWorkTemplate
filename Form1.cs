using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.IO;
using Xceed.Document.NET;
using Xceed.Words.NET;

namespace AnnWorkTemplate
{
    public partial class Form1 : Form
    {
        private string ExcelFile = string.Empty;    // путь к экселю                    
        readonly OpenFileDialog ofd = new OpenFileDialog();
        readonly string appPath = Path.GetDirectoryName(Application.ExecutablePath);    //путь к исполняемому файлу
        private readonly string TemplateFile = Path.GetDirectoryName(Application.ExecutablePath) + @"\Template.docx"; //путь к шаблону

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void GenerateWordsButton_Click(object sender, EventArgs e)
        {
            if (NumberTextBox.Text == string.Empty)
            {
                MessageBox.Show("Не введен номер удостоверения");
                return;
            }

            var number = int.Parse(NumberTextBox.Text); //номер начального удостоверения
            // var startDate = StartDate.Value.ToShortDateString();
            // var endDate = EndDate.Value.ToShortDateString();

            DirectoryInfo dirInfo = new DirectoryInfo(appPath + @"\Output\");   //директория для готовых файлов
            foreach (FileInfo file in dirInfo.GetFiles()) // каждый раз очищаем директорию от мусора по нажатию кнопки
            {
                file.Delete();
            }

            // Здесь идет экспорт в Word

            var wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                for (int counter = 0; counter < (DatabaseNames.Rows.Count-1); counter++)
                {
                    var wordDocument = wordApp.Documents.Open(TemplateFile);    //открываем шаблон
                    var name = DatabaseNames.Rows[counter].Cells[0].Value.ToString();
                    var fileName = DatabaseNames.Rows[counter].Cells[0].Value.ToString();
                    var firstSpace = name.IndexOf(" ");
                    name = name.Insert(firstSpace, "\r\n"); //перенос после имени
                    firstSpace = name.IndexOf(" ");
                    name = name.Remove(firstSpace-1, 2);
                    ReplaceWordStub("{name}", name, wordDocument);  //заменяем имя
                    ReplaceWordStub("{number}", number.ToString(), wordDocument);   //заменяем номер
                    number++;   //увеличиваем число

                    wordDocument.SaveAs(appPath + $@"\Output\{fileName}.docx"); //сохраняем файл с фамилией в названии в директорию
                    // wordApp.Visible = true;
                }
                MessageBox.Show("Все удостоверения сформированы");
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при формировании файлов. Обратитесь к разработчику.", 
                    "Critical Warning",
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit(); //закрываем процесс ворда
            }
            
        }

        private void ReplaceWordStub(string stubToReplace, string text, Word.Document wordDocument) //функция для поиска и замены текста в документе
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToReplace, ReplaceWith: text);
        }

        private void ReadExcelButton_Click(object sender, EventArgs e)
        {
            ofd.Title = "Выберите документ для загрузки данных";
            ofd.Filter = "Excel|*.xlsx|Excel 97-2003|*.xls";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                PathFileTextBox.Text = ofd.FileName;
                ExcelFile = ofd.FileName;
                var excelApp = new Excel.Application();
                excelApp.Visible = false;
                Excel.Workbook workbook;
                Excel.Worksheet NwSheet;
                Excel.Range ShtRange;
                DataTable dt = new DataTable();
                workbook = excelApp.Workbooks.Open(ofd.FileName, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                    Missing.Value);
                NwSheet = (Excel.Worksheet)workbook.Sheets.get_Item(1);
                ShtRange = NwSheet.UsedRange;
                for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                {
                    dt.Columns.Add(
                    new DataColumn((ShtRange.Cells[1, Cnum] as Excel.Range).Value2.ToString()));
                }
                for (int Rnum = 2; Rnum <= ShtRange.Rows.Count; Rnum++)
                {
                    DataRow dr = dt.NewRow();
                    for (int Cnum = 1; Cnum <= ShtRange.Columns.Count; Cnum++)
                    {
                        if ((ShtRange.Cells[Rnum, Cnum] as Excel.Range).Value2 != null)
                        {
                            dr[Cnum - 1] =
                            (ShtRange.Cells[Rnum, Cnum] as Excel.Range).Value2.ToString();
                        }
                    }
                    dt.Rows.Add(dr);
                    dt.AcceptChanges();
                }
                DatabaseNames.DataSource = dt;
                DatabaseNames.AutoResizeColumns();
                excelApp.Quit();
                MessageBox.Show("Все записи загружены.");
            }
        }

        private void MergeButton_Click(object sender, EventArgs e)  //используется библиотека DocX
        {
            try
            {
                string[] allWordDocuments = Directory.GetFiles(appPath + @"\Output\"); //получаем все документы в папке массивом
                string outputPath = appPath + @"\Output\Merged.docx";   //Путь где будет объединенный файл

                using (var document1 = DocX.Load(allWordDocuments[0])) //берем первый документ //DocX.Create(outputPath)
                {
                    for (int counter = 1; counter < allWordDocuments.Length; counter++) //перебираем все документы
                    {
                        using (var document2 = DocX.Load(allWordDocuments[counter]))
                        {
                            document1.InsertDocument(document2, true); //вставляем документ из массива в конец созданного
                        }
                    }
                    document1.SaveAs(outputPath);
                    MessageBox.Show("Все файлы объединены.");
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при объединении файлов. Обратитесь к разработчику.", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("При любой ошибке можно попробовать написать разработчику в телеграм.\n" +
                "Telegram: @Zunaveyne", 
                "Помощь", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Question);
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для правильной работы программы шаблон должен храниться в корне программы, называться Template и иметь формат docx. Все формируемые файлы находятся в папке Output в корне программы.\n\n\n" +
                "Программа написана только для использования в некоммерческих целях и только для печати конкретных удостоверений.\n" +
                "Copyright © 2020 Zunaveyne. All rights reserved.\n" +
                "Contacts: <shchelochkov.alex@gmail.com>\n" +
                "License: CC BY-NC 4.0", 
                "О программе", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Information);
        }

        private void DatabaseNames_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
