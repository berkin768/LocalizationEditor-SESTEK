using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using RavSoft.GoogleTranslator;

namespace LocalizationEditor
{
    public partial class Form1 : Form
    {
        private static DataTable newTable;
        private static List<string> tempDuplicatedRows = new List<string>();

        public Form1()
        {
            InitializeComponent();
            var dtCombined = XmlToDataTable();
            dataGridView.DataSource = dtCombined;

            dataGridView.Columns.Cast<DataGridViewColumn>()
                .ToList()
                .ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
        }

        public string[] FindFilePath()
        {
            var filePath = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");
            workingDirectory.Text = Directory.GetCurrentDirectory();
            return filePath;
        }

        private DataTable XmlToDataTable()
        {
            List<DataSet> dataSets = new List<DataSet>();

            foreach (var file in FindFilePath())
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(file);
                dataSets.Add(dataSet);
            }
            newTable = new DataTable("Table");
            newTable.Columns.Add("Name");

            foreach (DataSet dataSet in dataSets)
            {
                string language = dataSet.Tables["localizationDictionary"].Rows[0]["culture"] + "";
                newTable.Columns.Add(language.ToUpper());
                var dt = dataSet.Tables["text"];

                duplicateKeyControlAtStart(dt, language);

                if (dt != null)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var name = row["Name"] + ""; //KEYS
                        var value = row["value"] + ""; //VALUES
                        var rows = newTable.Select("Name = '" + name + "'"); //CONTROL

                        if (rows.Any()) //CONTROL PART
                        {
                            rows[0]["Name"] = name;
                            rows[0][language] = row["value"].ToString();
                        }
                        else
                        {
                            var newRow = newTable.NewRow(); //NEW ROW
                            newRow["Name"] = name;

                            newRow[language] = value; //ADD VALUE                                                   
                            newTable.Rows.Add(newRow); //ADD TO TABLE
                        }
                    }
                }
            }
            return newTable;
        }

        private bool isSelectedRowEmpty(int rowIndex)
        {
            var dataRow = dataGridView.Rows[rowIndex];
            foreach (DataGridViewCell column in dataRow.Cells)
            {
                if (rowIndex == dataGridView.RowCount - 1)
                    break;

                if (string.IsNullOrEmpty(column.Value + ""))
                {
                    addToComboBox(rowIndex, 1);
                    return true;
                }
            }
            removeFromComboBox(rowIndex, 1);
            return false;
        }

        private bool isAnyRowEmpty()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var flag = isSelectedRowEmpty(row.Index);
                if (flag)
                {                   
                    return true;
                }
            }          
            return false;
        }

        public void addToComboBox(int rowIndex, int selector)
        {
            if (selector == 0)
            {
                var lineNumber = "Line : " + (rowIndex + 1) + " , " + dataGridView.Rows[rowIndex].Cells[0].Value + "";
                if (!duplicatedComboBox.Items.Contains(lineNumber))
                {
                    duplicatedComboBox.Items.Add(lineNumber);
                    duplicatedComboBox.Text = duplicatedComboBox.Items[0].ToString();
                }
            }
            else
            {
                var lineNumber = "Line : " + (rowIndex + 1);
                if (!emptyComboBox.Items.Contains(lineNumber))
                {
                    emptyComboBox.Items.Add(lineNumber);
                    emptyComboBox.Text = emptyComboBox.Items[0].ToString();
                }
            }
        }

        private void removeFromComboBox(int rowIndex, int selector)
        {
            if (selector == 0)
            {
                if (duplicatedComboBox.Items.Contains("Line : " + (rowIndex + 1) + " , " + dataGridView.Rows[rowIndex].Cells[0].Value + ""))
                {
                    duplicatedComboBox.Items.Remove("Line : " + (rowIndex + 1) + " , " + dataGridView.Rows[rowIndex].Cells[0].Value + "");
                }
            }
            else
            {
                if (emptyComboBox.Items.Contains("Line : " + (rowIndex + 1)))
                {
                    emptyComboBox.Items.Remove("Line : " + (rowIndex + 1));
                }
            }
        }

        private int findIndexWithName(string keyName)
        {
            DataGridViewRow row = dataGridView.Rows
          .Cast<DataGridViewRow>()
          .Where(r => r.Cells["Name"].Value.ToString().Equals(keyName))
          .First();

            return row.Index;
        }

        private void highlightEmptyParts()
        {
            int emptyRowCount = 0;
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var flag = isSelectedRowEmpty(row.Index);
                if (flag)
                {
                    emptyRowCount++;
                    dataGridView.Rows[row.Index].Cells[0].Style.ForeColor = Color.Crimson;
                    dataGridView.Rows[row.Index].Cells[0].Style.Font = new Font("Tahoma", 10, FontStyle.Bold);
                    conditionLabel.Text = "EMPTY LINE";
                    emptyLabel.Text = "Errors At :";
                    emptyLabel.ForeColor = Color.Crimson;
                }
                else
                {
                    dataGridView.Rows[row.Index].Cells[0].Style.ForeColor = Color.Empty;
                    dataGridView.Rows[row.Index].Cells[0].Style.Font = new Font("Microsoft Sans Serif", 9);
                }
            }
            if(emptyRowCount == 0)
            {
                conditionLabel.Text = "";
                emptyLabel.Text = "";                
            }
        }

        private void dataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void focusRowOnGridView(int selectedRowIndex)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[selectedRowIndex].Selected = true;
            dataGridView.FirstDisplayedScrollingRowIndex = selectedRowIndex;
            dataGridView.Focus();
        }

        private void focusCellOnGridView(int selectedRowIndex, int selectedColumnIndex)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[selectedRowIndex].Cells[selectedColumnIndex].Selected = true;
        }

        private void focusHeaderOnGridView(int selectedRowIndex)
        {
            dataGridView.ClearSelection();
            dataGridView.Rows[selectedRowIndex].Selected = true;
        }

        private void dataGridView_MouseClick(object sender, MouseEventArgs e)
        {
            int currentMouseOverRow = dataGridView.HitTest(e.X, e.Y).RowIndex;
            int currentMouseOverCell = dataGridView.HitTest(e.X, e.Y).ColumnIndex;

            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();

                if (currentMouseOverCell >= 0 && currentMouseOverRow >= 0)
                    focusCellOnGridView(currentMouseOverRow, currentMouseOverCell);
                if (currentMouseOverCell < 0 && currentMouseOverRow >= 0)
                    focusHeaderOnGridView(currentMouseOverRow);


                if (currentMouseOverRow >= 0 && currentMouseOverCell >= 0)
                {
                    //  m.MenuItems.Add(new MenuItem("Kopyala", dataGridView_copy));
                    //  m.MenuItems.Add(new MenuItem("Kes", dataGridView_cut));
                    //   m.MenuItems.Add(new MenuItem("Sil", dataGridView_delete));
                    //  if (!string.IsNullOrEmpty(Clipboard.GetText()))
                    //       m.MenuItems.Add(new MenuItem("Yapıştır", dataGridView_paste));

                    if (!currentMouseOverCell.Equals(0))
                        m.MenuItems.Add(new MenuItem("Çevir", dataGridView_translate));
                }
                if (currentMouseOverCell == -1 && currentMouseOverRow >= 0)
                {
                    m.MenuItems.Add(new MenuItem("Satırı Sil", dataGridView_deleteRow));


                }
                m.Show(dataGridView, new Point(e.X, e.Y));
            }
        }

        public void dataGridView_translate(object sender, EventArgs e)
        {
            if (dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                {
                    if (oneCell.Selected)
                    {
                        string baseLang = dataGridView.Columns[oneCell.ColumnIndex].HeaderCell.Value + "";
                        Translator t = new Translator();
                        if (baseLang == "TR")
                        {
                            string translation = t.Translate(oneCell.Value + "", "Turkish", "English");
                            Form2 translateForm = new Form2(oneCell.Value + "", translation, "Turkish", "English", oneCell.OwningRow);
                            translateForm.ShowDialog();
                        }
                        else
                        {
                            string translation = t.Translate(oneCell.Value + "", "English", "Turkish");
                            Form2 translateForm = new Form2(oneCell.Value + "", translation, "English", "Turkish", oneCell.OwningRow);
                            translateForm.ShowDialog();
                        }
                    }
                }
            }
        }

        private void dataGridView_deleteRow(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView.SelectedRows)
            {
                if (!isUncommitedCell(item.Cells[0]))
                {
                    removeFromComboBox(item.Index, 1);
                    dataGridView.Rows.RemoveAt(item.Index);
                    dataGridView.Refresh();
                }
            }
        }

        public bool isUncommitedCell(DataGridViewCell cell)
        {
            return cell.RowIndex == dataGridView.RowCount - 1;
        }

        private void pasteOperations()
        {
            if (dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
                {

                    if (isUncommitedCell(oneCell))
                    {



                        DataRow newRow = newTable.NewRow();
                        newTable.Rows.Add(newRow);
                        dataGridView.Rows[dataGridView.Rows.Count - 2].Cells[oneCell.ColumnIndex].Value = Clipboard.GetText();
                    }

                    else if (oneCell.Selected)
                    {
                        oneCell.Value = Clipboard.GetText();
                    }
                }
            }
        }

        private void cutOperations()
        {
            foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
            {
                if (oneCell.Selected)
                {
                    Clipboard.SetDataObject(dataGridView.GetClipboardContent());
                    oneCell.Value = "";
                }
            }
        }

        private void deleteOperations()
        {
            foreach (DataGridViewCell oneCell in dataGridView.SelectedCells)
            {
                if (oneCell.Selected)
                    oneCell.Value = "";
            }
        }

        private void copyOperations()
        {
            if (dataGridView.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                Clipboard.SetDataObject(dataGridView.GetClipboardContent());
            }
        }

        private void dataGridView_paste(object sender, EventArgs e)
        {
            pasteOperations();
        }

        private void dataGridView_cut(object sender, EventArgs e)
        {
            cutOperations();
        }

        private void dataGridView_delete(object sender, EventArgs e)
        {
            deleteOperations();
        }

        private void dataGridView_copy(object sender, EventArgs e)
        {
            copyOperations();
        }

        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                copyOperations();
            }
            if (e.KeyCode == Keys.X && e.Modifiers == Keys.Control)
            {
                cutOperations();
            }

            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                pasteOperations();
            }

            if (e.KeyCode == Keys.Delete)
            {
                deleteOperations();
            }
        }

        private string findXMLFile(string docLanguage)
        {
            var filePath = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");
            //string filePath = Directory.GetFiles(Directory.GetCurrentDirectory(), "*" + docLanguage + "*");
            foreach (var file in filePath)
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(file);
                if (dataSet.Tables["localizationDictionary"] != null)
                {
                    if (!string.IsNullOrEmpty(docLanguage) & docLanguage == dataSet.Tables["localizationDictionary"].Rows[0]["culture"] + "")
                    {
                        return file;
                    }
                }

            }
            //return filePath;
            return "";
        }

        private void dataTableToXml()
        {
            foreach (DataColumn columns in newTable.Columns)
            {
                string docLanguage = columns.Caption.ToLower();
                string file = findXMLFile(docLanguage);
                if (!string.IsNullOrEmpty(file))
                    editXML(file, docLanguage);
            }
            MessageBox.Show("XML Documents are Saved", "Operation Completed");
        }

        private void editXML(string filePath, string language)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            doc.DocumentElement.RemoveAll();



            XmlElement root = doc.DocumentElement;
            root.SetAttribute("culture", language);

            XmlElement textsNode = doc.CreateElement("texts");
            root.AppendChild(textsNode);

            for (int i = 0; i < newTable.Rows.Count; i++)
            {
                XmlElement text = doc.CreateElement("text");
                text.SetAttribute("name", newTable.Rows[i][0].ToString());
                text.SetAttribute("value", newTable.Rows[i][language.ToUpper()].ToString());
                textsNode.AppendChild(text);
            }
            doc.Save(filePath);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {          
            var message = new StringBuilder();
            if (conditionLabel.Text == "EMPTY LINE")
            {
                message = new StringBuilder();
                message.AppendLine("Some columns are empty");
                foreach (var item in duplicatedComboBox.Items)
                {
                    message.AppendLine(item.ToString());
                }

                if (
                    MessageBox.Show(message.ToString(), "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==
                    DialogResult.Yes)
                {
                    dataTableToXml();
                }
            }
            else if (conditionLabel.Text == "DUPLICATE")
            {               
                MessageBox.Show("Some columns are duplicated", "Duplicated Keys");
            }
            else
            {
                dataTableToXml();
            }

        }

        private void dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.RowIndex != dataGridView.RowCount - 1)
            {
                if (string.IsNullOrEmpty(dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + ""))
                {
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);
                    using (Pen p = new Pen(Color.Red, 1))
                    {
                        Rectangle rect = e.CellBounds;
                        rect.Width -= 2;
                        rect.Height -= 2;
                        e.Graphics.DrawRectangle(p, rect);
                    }
                    e.Handled = true;
                }
            }
        }

        private void duplicatedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (duplicatedComboBox.Items.Count > 0)
            {
                string index = duplicatedComboBox.SelectedItem + "";
                int selectedRowIndex = Convert.ToInt32(index.Split(',')[0].Split(':')[1]);
                selectedRowIndex--;
                focusRowOnGridView(selectedRowIndex);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();

            foreach (DataColumn column in newTable.Columns)
            {
                if (!string.IsNullOrEmpty(searchBox.Text))
                    sb.AppendFormat("{0} Like '%{1}%' OR ", column.ColumnName, searchBox.Text);
            }
            if (!string.IsNullOrEmpty(sb.ToString()))
            {
                sb.Remove(sb.Length - 3, 3);
            }
            newTable.DefaultView.RowFilter = sb.ToString();

        }

        private void duplicateKeyControlAtStart(DataTable table, string language)
        {
            if (table != null)
            {
                var duplicates = table.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1);
                var message = new StringBuilder();

                if (duplicates.Any())
                {
                    foreach (var d in duplicates)
                    {
                        message.AppendLine("Key Name : " + d.Key);
                    }

                    message.AppendLine("--------------------------");
                    message.AppendLine("File : " + language.ToUpper() + ".xml");

                    if (MessageBox.Show(message.ToString(), "Duplicated Key", MessageBoxButtons.OK, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        Environment.Exit(0);
                    }
                }
            }

        }

        private void crossButton_Click(object sender, EventArgs e)
        {
            searchBox.Text = "";
            searchBox.Focus();
        }

        private void addNewLineButton_Click(object sender, EventArgs e)
        {
            DataRow newRow = newTable.NewRow();
            newTable.Rows.Add(newRow);
            focusRowOnGridView(dataGridView.RowCount - 1);
        }
      
        private bool CheckDublicatedInRuntime()
        {
            bool dublicated = false;


            var duplicates = newTable.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1);

            if (duplicates.Any())
            {
                duplicatedLabel.Text = "Duplicated Rows";
                duplicatedLabel.ForeColor = Color.Crimson;

                foreach (var duplicatedRow in duplicates)
                {
                    if (!string.IsNullOrEmpty(duplicatedRow.Key + ""))  //boş keyleri duplicate olarak görmesin 
                    {                       
                        tempDuplicatedRows.Add(duplicatedRow.Key + "");  //temp listeye ekle
                      
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            dublicated = true;
                            if (!isUncommitedCell(row.Cells[0]) && row.Cells[0].Value.ToString().Equals(duplicatedRow.Key + ""))
                            {
                                addToComboBox(row.Index, 0);
                                conditionLabel.Text = "DUPLICATE";
                            }
                        }
                    }
                }
                removeNonDuplicates();
            }
            else
            {
                if(conditionLabel.Text == "DUPLICATE")
                conditionLabel.Text = "";
                dublicated = false;
                duplicatedLabel.Text = "";                
                duplicatedComboBox.Items.Clear();
            }
            return dublicated;
        }

        private void removeNonDuplicates()
        {
            //TODO Duplicate olmayan keyler silinecek
            //duplicate keyler => var duplicates = newTable.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1); 
            //tempKey ler, duplicate olanların silinmesi zamanında kullanılacak

            /*var duplicates = newTable.AsEnumerable().GroupBy(r => r[0]).Where(gr => gr.Count() > 1);
            foreach (var key in tempDuplicatedRows)
            {
                var someCount = tempDuplicatedRows.Count(y => y == key);    
                for(int i = 0; i < someCount; i++)
                {
                    removeFromComboBox(findIndexWithName(key), 0);
                }                              
            }*/
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            highlightEmptyParts();
            CheckDublicatedInRuntime();
        }

        private void emptyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (emptyComboBox.Items.Count > 0)
            {
                string index = emptyComboBox.SelectedItem + "";
                int selectedRowIndex = Convert.ToInt32(index.Split(':')[1]);
                selectedRowIndex--;
                focusRowOnGridView(selectedRowIndex);
            }
        }
    }
}
