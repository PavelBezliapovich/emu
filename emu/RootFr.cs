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

namespace emu
{
    public partial class RootFr : Form
    {
        private EmuMicroprocessor _em;
        private int commandCounter = 0;
        private int _lineCounter = 0;
        private EmuMicroprocessorState _msState;
        public RootFr()
        {
            InitializeComponent();
            int k;
            _em = new EmuMicroprocessor();
            _msState = new EmuMicroprocessorState();
            _em.Init();
            dgRegisters.Columns.Add("name", "Регистр");
            dgRegisters.Columns.Add("value", "Значение");
            dgRegisters.Rows.Add(_em.Registers.Length);
            
            for (k = 0; k < _em.SysRegNames.Length; k++)
            {
                dgRegisters.Rows[k].Cells[0].Value = _em.SysRegNames[k];
            }
            for (; k < _em.Registers.Length; k++)
            {
                dgRegisters.Rows[k].Cells[0].Value = "R" + (k - _em.SysRegNames.Length).ToString();
            }
        }

        private void UpdateCPUState()
        {
            tbEIP.Text = this._em.ProgramMemory[commandCounter].ToString("X");
            tbBR1.Text = _msState.BR1;
            tbBR2.Text = _msState.BR2;
            tbEAX.Text = _msState.EAXPP;
            tbPK.Text = _msState.PK;
            tbPP.Text = _msState.EAXPP;

           /* {
                int row = i / 16;
                int col = i % 16;
                this.dataGridProgram.Rows[row].Cells[col].Value = this.cpu.ProgramMemory[i].ToString("X");
            }*/
           
            for (int i = 0; i < _em.RegistersCount; i++)
            {
                this.dgRegisters.Rows[i].Cells[1].Value = _em.Registers[i].ToString("X");
            }

            
        }

        private void SelectLineFromRichTextBox(RichTextBox rtBox, int lineNumber)
        {
            int n, p1, p2; 
            int ln = rtProgram.TextLength;
            p1 = ln;
            p2 = ln;
            for (int i = 0; i < ln; i++)
            {
                n = rtBox.GetLineFromCharIndex(i);

                if (n == lineNumber && p1 == ln)
                    p1 = i;

                if (n > lineNumber)
                {
                    p2 = i - 1;
                    break;
                }
               
             }
            rtBox.Select(p1, p2 - p1);
            rtBox.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sourceCode = rtProgram.Text;

            _em.Parse(sourceCode.Replace("\r\n", "\n").Split(new char[] { '\n' }));
                //this.btnReload_Click(null, null);
               // this.UpdateCPUState();
           // rtProgram.Enabled = false;
           UpdateCPUState();

        }

       

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
           var openDlg = new OpenFileDialog();
           if (openDlg.ShowDialog() == DialogResult.OK)
            {
                try
                {           
                    StreamReader f = new StreamReader(openDlg.FileName);
                    rtProgram.Text = f.ReadToEnd();
                    f.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var saveDlg = new SaveFileDialog();
            try
            {
                if (saveDlg.ShowDialog() == DialogResult.OK)
                {
                    var streamWriter = new StreamWriter(saveDlg.FileName);
                    streamWriter.WriteLine(rtProgram.Text);
                    streamWriter.Close();
                }
            }
            catch (Exception )
            {
                
                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            _msState = _em.NextStep();
            UpdateCPUState();
            SelectLineFromRichTextBox(rtProgram, _lineCounter);
            _lineCounter++;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            _em.SetReg("PC", 0);
            _em.SetReg("PCI", 0);
            _em.SetReg("CI", 0);
            _em.SetReg("CIA", 0);
            _em.SetReg("NI", 0);
            _em.SetReg("NIA", 0);
            _lineCounter = 0;
            this.UpdateCPUState();
        }
    }
}
