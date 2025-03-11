using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using ExcelCSharp_ns;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using wordCSharp_ns;

namespace AnrangoRamos
{
    public partial class frmVerifica: Form
    {
        public frmVerifica()
        {
            InitializeComponent();
        }
        clsExcel excel = new clsExcel();
        private void btn20File_Click(object sender, EventArgs e)
        {
                excel.istanziaApplicazione();
                for (int i = 1; i <= 20; i++)
                {
                    excel.creaWorkBook();
                    excel.rinominaFoglio(1, "GIORNI_QUANTITA");
                    excel.scriviCella("A1", "Lunedì");
                    excel.scriviCella("A2", "Martedì");
                    excel.scriviCella("A3", "Mercoledì");
                    excel.scriviCella("A4", "Giovedì");
                    excel.scriviCella("A5", "Venerdì");
                    excel.scriviCella("A6", "Sabato");
                    excel.scriviCella("A7", "Domenica");
                    for (int j = 1; j <= 7; j++)
                        excel.scriviFormula(j, 2, "=CASUALE.TRA(1,200)");

                    excel.salvaConNome(System.Windows.Forms.Application.StartupPath +"excel"+ i);
                    excel.chiudiCartella();

                }
            excel.chiudiExcel();
        }

                int[] somma = new int[7];
                float[] media = new float[7];
        string[] settimana =
        {
            "Lunedì",
            "Martedì",
            "Mercoledì",
            "Giovedì",
            "Venerdì",
            "Sabato",
            "Domenica"
        };
        private void btnMediaSommaGrafico_Click(object sender, EventArgs e)
        {
                excel.istanziaApplicazione();
                for (int i = 1; i <= 20; i++)
                {
                    excel.apri(System.Windows.Forms.Application.StartupPath+"excel" + i, false, 1);


                    for (int j = 0; j < 7; j++)
                    {
                        somma[j] += Convert.ToInt16(excel.leggiCella("B" + (j + 1)));
                    }

                    excel.chiudiCartella();
                }
                for (int i = 1; i <= 7; i++) media[i - 1] = somma[i - 1] / 20;
                //creazione file excel
                excel.creaWorkBook();
                excel.rinominaFoglio(1,"DATI");
                excel.scriviCella("A1", "GIORNO");
                for (int i = 2; i < 8; i++)
                excel.scriviCella("A"+i, settimana[i-2]);

                excel.scriviCella("B1", "MEDIA");
                excel.scriviCella("C1", "SOMMA");
                for (int j = 1 + 1; j <= 7 + 1; j++)
                {
                    excel.scriviCella("B" + j, media[j - 2].ToString("N2"));
                    excel.scriviCella("C" + j, somma[j - 2].ToString());
                }
            //grafico
            Microsoft.Office.Interop.Excel.Range datiGrafico = excel.impostaRange("A1", "B8");
                excel.aggiungiFoglio("GRAFICO");
                excel.creaGrafico(10, 10, 300, 150, Microsoft.Office.Interop.Excel.XlChartType.xlBarStacked, datiGrafico);

                excel.salvaConNome(System.Windows.Forms.Application.StartupPath + "excelMediaSommaGrafico");
                excel.chiudiCartella();

                excel.chiudiExcel();
            }

        private void frmVerifica_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        clsWord word = new clsWord();
        private Table table;

        private void btnRiepilogo_Click(object sender, EventArgs e)
        {
            word.creaDocumento(true);
            object start = 0, end = 0;
            word.impostaRange(ref start,ref end);
            table=word.creaTabella(start,end,8,3);
            word.scriviCella(table, 1, 1, "Giorno", WdCellVerticalAlignment.wdCellAlignVerticalCenter, WdParagraphAlignment.wdAlignParagraphCenter, true, 10, "verdana", WdColor.wdColorBlack);
            word.scriviCella(table, 1, 2, "Somma Quantità", WdCellVerticalAlignment.wdCellAlignVerticalCenter, WdParagraphAlignment.wdAlignParagraphCenter, true, 10, "verdana", WdColor.wdColorBlack);
            word.scriviCella(table, 1, 3, "media", WdCellVerticalAlignment.wdCellAlignVerticalCenter, WdParagraphAlignment.wdAlignParagraphCenter, true, 10, "verdana", WdColor.wdColorBlack);

            for (int i = 0; i < 7; i++)
            {
                word.scriviCella(table, i+2, 1, settimana[i], WdCellVerticalAlignment.wdCellAlignVerticalCenter, WdParagraphAlignment.wdAlignParagraphLeft, false, 10, "verdana", WdColor.wdColorBlack);
                word.scriviCella(table, i+2, 2, somma[i].ToString(), WdCellVerticalAlignment.wdCellAlignVerticalCenter, WdParagraphAlignment.wdAlignParagraphRight, false, 10, "verdana", WdColor.wdColorBlack);
                word.scriviCella(table, i + 2, 3, media[i].ToString("N2"), WdCellVerticalAlignment.wdCellAlignVerticalCenter, WdParagraphAlignment.wdAlignParagraphRight, false, 10, "verdana", WdColor.wdColorBlack);
            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            File.Delete(System.Windows.Forms.Application.StartupPath + "riepilogo.docx");
            File.Delete(System.Windows.Forms.Application.StartupPath + "excelMediaSommaGrafico.xlsx");
            for (int i = 1; i <= 20; i++)
                File.Delete(System.Windows.Forms.Application.StartupPath + $"excel{i}.xlsx");
        }
    }
}
