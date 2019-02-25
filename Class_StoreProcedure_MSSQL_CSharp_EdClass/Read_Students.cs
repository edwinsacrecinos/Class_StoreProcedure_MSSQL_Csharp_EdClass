using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class_StoreProcedure_MSSQL_CSharp_EdClass
{
    public partial class Read_Students : Form
    {
        public Read_Students()
        {
            InitializeComponent();
        }

        private void Select_Students()
        {
            BLL.Read_students query = new BLL.Read_students();
            try
            {
                this.dataGridView1.DataSource = query.ReadStudents();
                this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
                this.dataGridView1.Refresh();
            }
            catch (Exception)
            {
                this.dataGridView1.DataSource = null;
                MessageBox.Show("Error in connection");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Simple_Read newform = new Simple_Read();
            newform.ShowDialog();
        }

        private void Read_Students_Load(object sender, EventArgs e)
        {
            Select_Students();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Create newform = new Create();
            newform.ShowDialog();
            Select_Students();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DAL.VarGlobal Var_Global = DAL.VarGlobal.Instance();
            Var_Global.Global_id_s = this.dataGridView1.CurrentRow.Cells[0].EditedFormattedValue.ToString();
            Var_Global.Global_name_s = this.dataGridView1.CurrentRow.Cells[1].EditedFormattedValue.ToString();
            Var_Global.Global_last_s = this.dataGridView1.CurrentRow.Cells[2].EditedFormattedValue.ToString();
            Var_Global.Global_section_s = this.dataGridView1.CurrentRow.Cells[3].EditedFormattedValue.ToString();
            Var_Global.Global_course_s = this.dataGridView1.CurrentRow.Cells[4].EditedFormattedValue.ToString();
            Var_Global.Global_note_s = this.dataGridView1.CurrentRow.Cells[5].EditedFormattedValue.ToString();
            Var_Global.Global_state_s = this.dataGridView1.CurrentRow.Cells[6].EditedFormattedValue.ToString();
            Update newform = new Update();
            newform.ShowDialog();
            Select_Students();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BLL.Delete_students query = new BLL.Delete_students();
            int id = Convert.ToInt32(this.dataGridView1.CurrentRow.Cells[0].EditedFormattedValue);
            string MyResult = query.DeleteStudents(id);
            MessageBox.Show(MyResult);
            Select_Students();
        }
    }
}
