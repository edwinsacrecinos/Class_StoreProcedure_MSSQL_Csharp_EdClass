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
    public partial class Simple_Read : Form
    {
        public Simple_Read()
        {
            InitializeComponent();
        }

        private void Simple_Read_Load(object sender, EventArgs e)
        {
            BLL.Read_students query = new BLL.Read_students();
            this.dataGridView1.DataSource = query.ReadNotes();
            this.dataGridView1.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10);
            this.dataGridView1.Refresh();
        }
    }
}
