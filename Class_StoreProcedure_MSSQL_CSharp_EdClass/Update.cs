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
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }
        DAL.VarGlobal Var_Global = DAL.VarGlobal.Instance();
        private void Update_Load(object sender, EventArgs e)
        {
            textBox1.Text = Var_Global.Global_id_s;
            textBox2.Text = Var_Global.Global_name_s;
            textBox3.Text = Var_Global.Global_last_s;
            textBox4.Text = Var_Global.Global_section_s;
            textBox5.Text = Var_Global.Global_course_s;
            textBox6.Text = Var_Global.Global_note_s;
            textBox7.Text = Var_Global.Global_state_s;
        }
        BLL.Update_students query = new BLL.Update_students();
        private void button1_Click(object sender, EventArgs e)
        {
            string MyResult = query.UpdateStudents(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text,
                                                   textBox4.Text, textBox5.Text, Convert.ToInt32(textBox6.Text), textBox7.Text);
            MessageBox.Show(MyResult);
            this.Close();
        }
    }
}
