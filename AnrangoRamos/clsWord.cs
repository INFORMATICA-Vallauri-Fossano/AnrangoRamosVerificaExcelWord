using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;

namespace wordCSharp_ns
{
    public class clsWord
    {
        //applicazione word
        _Application myWord;
        //documento word
        Document myDoc;
        public void creaDocumento(bool visible = true)
        {
            //istanzio applicazione word
            myWord = new Microsoft.Office.Interop.Word.Application();
            myWord.Visible = visible;
            //istanzio documento
            myDoc = myWord.Documents.Add();
        }

        public void salvaChiudi(string nomeFile = "")
        {
            if (nomeFile == "")
                myDoc.Save();//apre finestra dialogo e chiede
            else
                myDoc.SaveAs(nomeFile, WdSaveFormat.wdFormatDocumentDefault); //salva con path e nome
            //
            myDoc.Close();//chiude il documento
            myWord.Quit();//chiude l'applizazione
        }

        public void chiudi()
        {
            myDoc.Saved = true; //forzo il true (se le modifiche son state salvate)
            myDoc.Close();//chiude il documento
            myWord.Quit();//chiude l'applizazione
        }

        public void impostaRange(ref object start, ref object end)
        {
            start = myDoc.Sentences[myDoc.Sentences.Count].End - 1;
            end = myDoc.Sentences[myDoc.Sentences.Count].End;
        }

        public void inserisciTesto(object start, object end, string testo,
            string font = "Arial", string size = "12", bool bold = false,
            bool italic = false, string sottolineato = "None",
            string allineamento = "Left", string colore = "Black")
        {
            Range myRange = myDoc.Range(ref start, ref end);
            myRange.Text = testo + "\n";
            myRange.Font.Name = font;
            myRange.Font.Size = Convert.ToInt32(size);
            myRange.Bold = Convert.ToInt32(bold);
            myRange.Italic = Convert.ToInt32(italic);
            WdUnderline u = (WdUnderline)Enum.Parse(typeof(WdUnderline),
                "wdUnderline" + sottolineato);
            myRange.Underline = u;
            WdParagraphAlignment a = (WdParagraphAlignment)Enum.Parse(typeof(WdParagraphAlignment),
                "wdAlignParagraph" + allineamento);
            myRange.ParagraphFormat.Alignment = a;
            WdColor c = (WdColor)Enum.Parse(typeof(WdColor),
                "wdColor" + colore);
            myRange.Font.Color = c;
        }

        public void impostaFont(ComboBox cmbFont)
        {
            foreach (FontFamily family in FontFamily.Families)
                cmbFont.Items.Add(family.Name);
            cmbFont.SelectedIndex = 11;
        }

        public void impostaSize(ComboBox cmbSize)
        {
            for (int i = 8; i < 43; i++)
            {
                cmbSize.Items.Add(i.ToString());
            }
            cmbSize.SelectedIndex = 4;
        }

        public void impostaSottolineato(ComboBox cmbSottolineato)
        {
            string[] wdU = (string[])Enum.GetNames(typeof(WdUnderline));
            foreach (string sottolineato in wdU)
                cmbSottolineato.Items.Add(sottolineato.Substring(11));
            cmbSottolineato.SelectedIndex = 0;
        }

        public void impostaAllineamento(ComboBox cmbAllineamento)
        {
            string[] wdA = (string[])Enum.GetNames(typeof(WdParagraphAlignment));
            foreach (string allineato in wdA)
                cmbAllineamento.Items.Add(allineato.Substring(16));
            cmbAllineamento.SelectedIndex = 0;
        }

        public void impostaColore(ComboBox cmbColore)
        {
            string[] wdC = (string[])Enum.GetNames(typeof(WdColor));
            foreach (string colore in wdC)
                cmbColore.Items.Add(colore.Substring(7));
            cmbColore.SelectedIndex = 0;
        }

        public void impostaTabella(ComboBox cmbRighe, ComboBox cmbColonne)
        {
            for (int i = 1; i < 6; i++)
            {
                cmbRighe.Items.Add(i.ToString());
                cmbColonne.Items.Add(i.ToString());
            }
            cmbRighe.SelectedIndex = 1;
            cmbColonne.SelectedIndex = 1;
        }

        public Table creaTabella(object start, object end, int r, int c)
        {
            Table myTable;
            Range myRange = myDoc.Range(ref start, ref end);
            myTable = myDoc.Tables.Add(myRange, r, c);
            myTable.Borders.Enable = 1;
            return myTable;
        }

        public void scriviCella(Table tabella, int r, int c, string testo,
            WdCellVerticalAlignment vAlign, WdParagraphAlignment oAlign,
            bool bold, int size, string font, WdColor colore)
        {
            tabella.Cell(r, c).Range.Text = testo;
            tabella.Cell(r, c).Range.Cells.VerticalAlignment = vAlign;
            tabella.Cell(r, c).Range.Paragraphs.Alignment = oAlign;
            tabella.Cell(r, c).Range.Bold = Convert.ToInt32(bold);
            tabella.Cell(r, c).Range.Font.Size = size;
            tabella.Cell(r, c).Range.Font.Name = font;
            tabella.Cell(r, c).Range.Font.Color = colore;
        }

        public string selezionaTesto(object start, object end)
        {
            string testo = "";
            Range myRange = myDoc.Range(ref start, ref end);
            myRange.Select();
            testo = myRange.Text;
            return testo;
        }

        public bool ricercaTesto(string testoRicercare, ref object start,
            ref object end, bool sostituisci, string testoSostituire)
        {
            bool trovato = false;
            object findText = testoRicercare;
            object replaceText = testoSostituire;
            object ms = System.Type.Missing; //in caso di mancato parametro
            //
            myWord.Selection.Find.ClearFormatting();//case unsensitive
            myWord.Selection.Find.Replacement.ClearFormatting();
            //
            myWord.Selection.Start = myDoc.Content.Start; //inizio del documento
            myWord.Selection.End = myDoc.Content.End; //fine
            //
            if (sostituisci)
            {
                if (myWord.Selection.Find.Execute(ref findText, ref ms,
                    ref ms, ref ms, ref ms, ref ms, ref ms, ref ms, ref ms,
                    ref replaceText, WdReplace.wdReplaceAll))
                    trovato = true;
            }
            else
            {
                //N.B. trova solo la prima occorrenza
                if (myWord.Selection.Find.Execute(ref findText))
                    trovato = true;
            }
            //
            if (trovato)
            {
                start = myWord.Selection.Start;
                end = myWord.Selection.End;
            }
            return trovato;
        }

        public void creaPDF(string path, bool visualizzaPDF)
        {
            myDoc.ExportAsFixedFormat(path, WdExportFormat.wdExportFormatPDF, visualizzaPDF);
        }

        public void stampa()
        {
            myDoc.PrintOut();
        }

        public void apriDocumento(string myFile)
        {
            myWord = new Application();
            myWord.Visible = false;
            myDoc = myWord.Documents.Open(myFile);
        }


        public void CreateWordDocument(string filePath)
        {
            myWord = new Application();
            myDoc = myWord.Documents.Add();

            // Save and close
            myDoc.SaveAs2(filePath, WdSaveFormat.wdFormatDocumentDefault);
            myDoc.Close();
            myWord.Quit();
        }


        public void OpenWordDocument(string filePath)
        {
            myWord = new Application();
            myWord.Visible = true; // Show Word window

            object missing = Type.Missing;
            object file = filePath;

            myDoc = myWord.Documents.Open(ref file, ref missing, ref missing, ref missing);
        }

    }
}