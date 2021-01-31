using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trucks
{
    static class clsSetting
    {
        public const string DB_NAME = "trucks";
    // HACK: utenza Db
        public const string DB_USERNAME = "trucks";
        public const string DB_PASSWORD = "truckspwd";
      //public const string DB_USERNAME = "sa";
      //public const string DB_PASSWORD = "SaAdmin001";

    public const bool ATTIVA_XML = true;

    private static string param_db_Server;

    public static string param_path_save_folder;

    public static string param_path_save_pdf
    {
      get
      {
        if (param_path_save_folder == "")
          return param_path_save_folder;
        else
          return param_path_save_folder + "\\PDF";
      }
    }

    public static string param_path_save_xml
    {
      get
      {
        if (param_path_save_folder == "")
          return param_path_save_folder;
        else
          return param_path_save_folder + "\\XML";
      }
    }

    public static string param_path_save_att
    {
      get
      {
        if (param_path_save_folder == "")
          return param_path_save_folder;
        else
          return param_path_save_folder + "\\Allegati";
      }
    }

    public static bool param_stampa_logo_docu;
        public static bool param_stampa_logo_solo_pdf;
        public static bool param_stampa_dati_az_docu;
        public static bool param_stampa_dati_az_solo_pdf;
        public static string param_note_fattura;
        public static decimal param_coefficente;
        public static decimal param_prezzo_carburante;
        public static int param_model_fattura;

        public static void LoadParam()
        {
            Load_RegistryParam();
            Load_OtherParam();
        }

        public static string DB_Server
        {
            get { return clsSetting.param_db_Server; }
            set 
            { 
              clsSetting.param_db_Server = value; 
              Microsoft.Win32.RegistryKey key;
              key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Trucks");
              key.SetValue("DBServer", value);
              key.Close();  
            }
        }

        public static void Load_RegistryParam()
        {
              Microsoft.Win32.RegistryKey key;
              key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Trucks");
              clsSetting.param_db_Server= key.GetValue("DBServer", "localhost").ToString() ;
              key.Close();          
        }

        private static void Load_OtherParam()
        {
            string strSql = "Select path_save_pdf, stampa_logo_docu,stampa_logo_solo_pdf,stampa_dati_az_docu, stampa_dati_az_solo_pdf, note_fattura, coefficente, prezzo_carburante, id_model_fat from Parametri ";

            if (clsDataBase.ExecuteQuery(strSql))
            {
                if (clsDataBase.vetDbReader[0].Read())
                {
          param_path_save_folder = clsDataBase.GetStringValue("path_save_pdf");
          param_stampa_logo_docu = clsDataBase.GetBoolValue("stampa_logo_docu");
                    param_stampa_logo_solo_pdf = clsDataBase.GetBoolValue("stampa_logo_solo_pdf");
                    param_stampa_dati_az_docu = clsDataBase.GetBoolValue("stampa_dati_az_docu");
                    param_stampa_dati_az_solo_pdf = clsDataBase.GetBoolValue("stampa_dati_az_solo_pdf");
                    param_note_fattura = clsDataBase.GetStringValue("note_fattura");
                    param_coefficente = clsDataBase.GetDecimalValue("coefficente");
                    param_prezzo_carburante = clsDataBase.GetValutaValue("prezzo_carburante");
                    param_model_fattura = clsDataBase.GetIntValue("id_model_fat");
                    clsDataBase.CloseDataReader(); 
                }
                else
                {
                    clsDataBase.CloseDataReader(); 
                    //Nessun parametro presente inserisco i valori di default
                    System.Reflection.Assembly exe = System.Reflection.Assembly.GetEntryAssembly(); 
                    string strPathDefault = System.IO.Path.GetDirectoryName(exe.Location) + "\\PDF";
                    strSql = "Insert into  Parametri (path_save_pdf, stampa_logo_docu,stampa_logo_solo_pdf,stampa_dati_az_docu, stampa_dati_az_solo_pdf, note_fattura, coefficente, prezzo_carburante, last_num_fattura, last_date_fattura, id_model_fat) " +
                                            " values ('" + strPathDefault + "', 'true', 'false', 'true', 'false','',0,0,0," + clsDataBase.SQL_ConvertStrToData("01/01/2010") + ", 0)";
                    if (clsDataBase.ExecuteNonQuery(strSql))
                        Load_OtherParam();
                }

            }
            
        }

       

        public static bool Save_OtherParam()
        {
            string strSql = "";
            
            strSql = "Update Parametri set " +
                        " path_save_pdf = '" + param_path_save_folder + "'"+
                        ", stampa_logo_docu = '" + param_stampa_logo_docu.ToString().ToLower() + "'" +
                        ", stampa_dati_az_docu = '" + param_stampa_dati_az_docu.ToString().ToLower()  + "'" +
                        ", note_fattura = '" + param_note_fattura.Replace("'", "''") + "'" +
                        ", prezzo_carburante = " + param_prezzo_carburante.ToString().Replace(",", ".") + "" +
                        ", coefficente = " + param_coefficente.ToString().Replace(",", ".") + "" +
                        ", id_model_fat = " + param_model_fattura;
            return clsDataBase.ExecuteNonQuery(strSql);
        }

        public static bool VerificaLicenza()
        {
            return true;
            bool RetValue = false;
            string strRegVale = "";
            string strLicMese = "";
            string strLicAnno = "";
            
            Microsoft.Win32.RegistryKey key;

            try
            {
                key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\System_DM");
                //System.Windows.Forms.MessageBox.Show("0");
                //key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\System_DM");
                strRegVale = key.GetValue("SETTRK", "xxxxxxxxxxxxxxxxx01xxxxx10xxxxxx").ToString();
                //System.Windows.Forms.MessageBox.Show(strRegVale);
                key.Close();


                strLicMese = strRegVale.Substring(17, 2);
                strLicAnno = strRegVale.Substring(24, 2);
                DateTime dataLic = new DateTime(2000 + Convert.ToInt32(strLicAnno), Convert.ToInt32(strLicMese), 1);
                if (dataLic >= DateTime.Today) RetValue = true;
            }
            catch (Exception)
            {
                //System.Windows.Forms.MessageBox.Show(e.Message);
                RetValue = false;
            }

            if (! RetValue)
                System.Windows.Forms.MessageBox.Show("La licenza del software è scaduta.\n\nPer informazioni contattare la società DAMACON (www.damacon.it)", "Attenzione", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);

            return RetValue; 
            //return true; 

        }

    }
}
