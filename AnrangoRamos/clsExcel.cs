using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Microsoft.Office.Interop.Excel;

namespace ExcelCSharp_ns
{
    public class clsExcel
    {
        Application myExcel;
        Workbook myWorkbook;
        Worksheet myWorksheet;
        Range myRange;
        //
        private bool visibile = false;
        public bool Visibile
        { 
            get { return visibile; } 
            set { 
                visibile = value;
                myExcel.Visible = visibile;
            } 
        }
        //
        public void istanziaApplicazione()
        {
            myExcel = new Application();
        }
        public void creaWorkBook()
        {
            myWorkbook = myExcel.Workbooks.Add();
        }

        public void aggiungiFoglio(string nome)
        {
            myWorkbook.Worksheets.Add(
                After: myWorkbook.Sheets[myWorkbook.Sheets.Count]);
            int pos = myWorkbook.Worksheets.Count;
            myWorksheet = (Worksheet)myWorkbook.Worksheets.Item[pos];
            myWorksheet.Name = nome;
        }

        public void selezionaFoglio(int foglio)
        {
            myWorksheet = (Worksheet)myWorkbook.Worksheets.get_Item(foglio); //assegna il foglio a myWorksheet
            myWorkbook.Sheets[foglio].Select(); //seleziona soltanto
        }

        public void rinominaFoglio(int foglio, string nome)
        {
            myWorksheet = (Worksheet)myWorkbook.Worksheets.Item[foglio];
            myWorksheet.Name = nome;
        }

        public void scriviCella(int r, int c, string valore)
        {
            myWorksheet.Cells[r,c] = valore;
        }
        public void scriviCella(string cella, string valore)
        {
            myWorksheet.Range[cella].Value = valore;
        }
        public void scriviCella(string cellaI, string cellaF, string valore)
        {
            myRange = myWorksheet.get_Range(cellaI, cellaF);
            myRange.Value = valore;
        }

        public void aspettoCella(string cellaI, string cellaF, string font,
            int size, bool bold, bool italic, XlRgbColor bc, XlRgbColor fc)
        {
            myRange = myWorksheet.get_Range(cellaI, cellaF);
            myRange.Font.Name = font;
            myRange.Font.Size=size;
            myRange.Font.Bold=bold;
            myRange.Font.Italic=italic;
            myRange.Interior.Color = bc;
            myRange.Font.Color=fc;
            myRange.EntireColumn.AutoFit(); //larghezza automatica
        }

        public void bordoCella(string cellaI, string cellaF,
            XlLineStyle lineStyle, XlBorderWeight borderWeight)
        {
            myRange = myWorksheet.get_Range(cellaI, cellaF);
            myRange.BorderAround2(lineStyle,borderWeight);
        }

        public void scriviFormula(int r, int c, string formula)
        {
            myWorksheet.Cells[r, c].FormulaLocal = formula;
        }
        public void scriviFormula(string cella, string formula)
        {
            myWorksheet.Range[cella].FormulaLocal = formula;
        }

        public ChartObject creaGrafico(double left, double top,
            double width, double height, 
            XlChartType chartType, string cellaI, string cellaF)
        {
            ChartObject myChart = 
                (ChartObject)myWorksheet.ChartObjects().Add(
                    left, top, width, height);
            myChart.Chart.ChartType = chartType;
            myRange = myWorksheet.get_Range(cellaI,cellaF);
            myChart.Chart.SetSourceData(myRange);
            ////proprietà del grafico
            //myChart.Chart.HasTitle = true;
            //myChart.Chart.ChartTitle.Text = "Grafico Funzione";
            //myChart.Chart.HasLegend = true;
            //Series mySerie = (Series)myChart.Chart.SeriesCollection(1);
            ////mySerie.HasDataLabels = true;
            //mySerie.Name = "f(x)";
            return myChart;
        }
        public ChartObject creaGrafico(double left, double top,
            double width, double height,
            XlChartType chartType, Range r)
        {
            ChartObject myChart =
                (ChartObject)myWorksheet.ChartObjects().Add(
                    left, top, width, height);
            myChart.Chart.ChartType = chartType;
            myChart.Chart.SetSourceData(r);
            ////proprietà del grafico
            //myChart.Chart.HasTitle = true;
            //myChart.Chart.ChartTitle.Text = "Grafico Funzione";
            //myChart.Chart.HasLegend = true;
            //Series mySerie = (Series)myChart.Chart.SeriesCollection(1);
            ////mySerie.HasDataLabels = true;
            //mySerie.Name = "f(x)";
            return myChart;
        }
        public Range impostaRange(string cellaI, string cellaF)
        {
            return myWorksheet.get_Range(cellaI, cellaF);
        }

        public void salvaConNome(string path)
        {
            myWorkbook.SaveAs(path);
        }

        public void chiudiCartella()
        {
            myWorkbook.Close();
        }

        public void chiudiExcel()
        {
            myExcel.Quit();
        }

        public void esportaGrafico(string path, string estensione, ChartObject myChart)
        {
            myChart.Chart.Export(path, estensione);
        }

        public void apri(string path, bool visible, int foglio)
        {
            myExcel.Visible = visible;
            myWorkbook = myExcel.Workbooks.Open(path);
            myWorkbook.Sheets[foglio].Select(); //seleziona soltanto
            myWorksheet = (Worksheet)myWorkbook.Worksheets.get_Item(foglio); //assegna il foglio a myWorksheet

        }

        public string leggiCella(string cella)
        {
            string valore = "";
            valore = Convert.ToString(myWorksheet.Cells.Range[cella].Value);
            return valore;
        }
    }
}
