using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_StoreProcedure_MSSQL_CSharp_EdClass.DAL
{
    //Class type Singleton
    public class VarGlobal
    {
        private static VarGlobal data;
        private VarGlobal() { }

        public static VarGlobal Instance()
        {
            if (data == null)
            {
                data = new VarGlobal();
            }
            return data;
        }

        #region Global var data
        public string Global_id_s { get; set; }
        public string Global_name_s { get; set; }
        public string Global_last_s { get; set; }
        public string Global_section_s { get; set; }
        public string Global_course_s { get; set; }
        public string Global_note_s { get; set; }
        public string Global_state_s { get; set; }
        #endregion

    }
}
