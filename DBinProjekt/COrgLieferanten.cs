using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DBinProjekt
{
     public class COrgLieferanten
    {

        public COrgLieferanten()
        {
                       getDaten();
                       Lifnr = dt.Rows[0].ItemArray[0] as string;
            Matchcode = dt.Rows[0].ItemArray[1] as string;
        }
        DataRow row = null;
        DataTable dt = new DataTable();
        private string _lifnr;

        public string Lifnr
        {

            get
            {
                return _lifnr;
            }

            set
            {
                _lifnr = value;
            }

        }

        private string _mcod1;

        public string Matchcode
        {

            get {
                return _mcod1;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    _mcod1 = "leerer Name!!!";
                }
                else {
                    _mcod1 = value;
                }
            }

        }


        private DataTable getDaten()
        {
            
            using (MyContextDataContext myctx = new MyContextDataContext())
            {

                dt.Columns.Add("Lifnr");
                dt.Columns.Add("Matchcode");

                var query = (from b in myctx.orgLieferanten
                             where b.dbbestand == "PRD"
                             select b);

                foreach (var dr in query)
                {
                    row = dt.NewRow();
                    dt.Rows.Add(dr.lifnr, dr.mcod1);
                }

                return dt;

            }



        }

        public static string safe(string strlifnr, string strmcod1) 
        {
            using (MyContextDataContext myctx = new MyContextDataContext(Properties.Settings.Default.MyDBConnectionString))
            {

           // MyContextDataContext myctx = new MyContextDataContext();

                var update = (from b in myctx.orgLieferanten
                              where b.dbbestand == "PRD" && (b.lifnr == strlifnr)
                              select b).SingleOrDefault();
                            
            update.mcod1 = strmcod1;
            //update.mcod1 = "bla blubb GmbH";
            

            try
                            {
                                myctx.SubmitChanges();

                            }
                            catch (Exception ex)
                            {
                                
                                return ex.Message;
                            }
            finally
            {
                update = null;
                myctx.Dispose();
            }
            
                return "1";

            }
           
        }

    }
}
