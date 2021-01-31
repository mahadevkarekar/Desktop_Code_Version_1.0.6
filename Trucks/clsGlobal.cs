using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Trucks
{
    public static class clsGlobal
    {
        public struct _Viaggio
        {
            public int Id_Articolo;
            public int Id_LocalitaA;
            public int Id_LocalitaB;
            public int ID_Truck;
            public string Num_Viaggio;
            public DateTime Data;
            public string Descr;
            public decimal Qta;
            public string Um;
            public decimal Prezzo;
            public decimal IVA;
            public decimal KM;
        }

        public struct _DettFat
        {
            public int Id_Cliente;

            //public int Id_Articolo;
            public string CodArticolo;
            
            //public int Id_Tratta;
            public string Tratta;
            
            //public int ID_Truck;
            public string Truck;

            public string DDT;
            public DateTime Data;
            public string Descr;
            public decimal Qta;
            public string Um;
            public decimal Prezzo;
            public decimal IVA;
            public decimal KM;
            public string Note;
            public int ID_Viaggio;
            public int IdIva;
        }

        public enum ETypeTable
        {
            TT_IVA = 0,
            TT_UNIT_MISURA = 1,
            TT_CATEGORIA = 2,
            TT_ASSICURAZIONI = 3,
            TT_TIP_PAGAMENTO = 4,
            TT_MOD_PAGAMENTO = 5,
            TT_BANCHE_AZ = 6,
            TT_DISTANZE = 7,
            TT_LOCALITA = 8,
            TT_AUTOMEZZI = 9,
            TT_ARTICOLI = 10,
            TT_CLIENTI = 11,
            TT_IVA_DESCR = 12,
            TT_ARTICOLI_DESC_COD = 13,
            TT_ESENZIONI = 14,
            XML_REGIME = 15,
            XML_NAZIONE = 16,
            XML_DIVISA = 17,
            XML_NATURA = 18,
            XML_COND_PAGAMENTO = 19,
            XML_MOD_PAGAMENTO = 20,
            TT_DESCR_BREVI = 21
          };

        public static string GetCaptionTabForm(ETypeTable TypeTable)
        {
            string sTextCaption = "Gestione Tabelle";
            switch (TypeTable)
            {
                case ETypeTable.TT_IVA:
                    sTextCaption += " - Aliquote IVA";
                    break;
                case ETypeTable.TT_UNIT_MISURA:
                    sTextCaption += " - Unità di Misura";
                    break;
                case ETypeTable.TT_CATEGORIA:
                    sTextCaption += " - Categorie";
                    break;
                case ETypeTable.TT_ASSICURAZIONI:
                    sTextCaption += " - Assicurazioni";
                    break;
                case ETypeTable.TT_TIP_PAGAMENTO:
                    sTextCaption += " - Tipologia di Pagamento";
                    break;
                case ETypeTable.TT_MOD_PAGAMENTO:
                    sTextCaption += " - Modalità di Pagamento";
                    break;
                case ETypeTable.TT_LOCALITA:
                    sTextCaption += " - Località";
                    break;
                case ETypeTable.TT_ESENZIONI:
                    sTextCaption += " - Esenzioni";
                    break;
                case ETypeTable.TT_DESCR_BREVI:
                    sTextCaption += " - Descrizioni brevi fattura";
                    break;
                default:
                    break;
            }

            return sTextCaption;
        }

        public static int ShowModal_GestTab_ForSelect(clsGlobal.ETypeTable Type, ComboBox objCombo = null)
        {
            int RetValue = 0;

            switch (Type)
            {
                case ETypeTable.TT_IVA:
                case ETypeTable.TT_IVA_DESCR:    
                case ETypeTable.TT_UNIT_MISURA:                    
                case ETypeTable.TT_CATEGORIA:
                case ETypeTable.TT_LOCALITA:
                case ETypeTable.TT_MOD_PAGAMENTO:
                case ETypeTable.TT_ESENZIONI:
                    frmGestTab frmTab = new frmGestTab();

                    if (Type == ETypeTable.TT_IVA_DESCR)
                        frmTab.TypeTable = ETypeTable.TT_IVA;
                    else
                        frmTab.TypeTable = Type;
                    frmTab.IsInsertOnly = true;
                    frmTab.ShowDialog();
                    RetValue = frmTab.IdSel;
                    break;
                case ETypeTable.TT_ASSICURAZIONI:
                    break;
                case ETypeTable.TT_TIP_PAGAMENTO:
                    frmTipoPag frmTabTipoPag = new frmTipoPag();

                    frmTabTipoPag.IsInsertOnly = true;
                    frmTabTipoPag.ShowDialog();
                    RetValue = frmTabTipoPag.IdSel;
                    break;
                case ETypeTable.TT_BANCHE_AZ:
                    frmBanche frmTabBanche = new frmBanche();

                    frmTabBanche.IsInsertOnly = true;
                    frmTabBanche.ShowDialog();
                    RetValue = frmTabBanche.IdSel;
                    break;
                case ETypeTable.TT_DISTANZE:
                    frmDistanze frmTabDist = new frmDistanze();

                    frmTabDist.ShowDialog();
                    RetValue = frmTabDist.IdSel;
                    break;
                case ETypeTable.TT_AUTOMEZZI:
                    frmModAutomezzi frmTabTruck = new frmModAutomezzi();

                    frmTabTruck.ShowDialog();
                    RetValue = frmTabTruck.IdSel;
                    break;
                case ETypeTable.TT_ARTICOLI:
                case ETypeTable.TT_ARTICOLI_DESC_COD:
                    frmModArticoli frmTabArt = new frmModArticoli();

                    frmTabArt.ShowDialog();
                    RetValue = frmTabArt.IdSel;
                    break;
                case ETypeTable.TT_CLIENTI:
                    frmModCliente frmTabCli = new frmModCliente();

                    frmTabCli.ShowDialog();
                    RetValue = frmTabCli.IdSel;
                    break;
                default:
                    break;
            }

            if (objCombo != null)
            {
                if (RetValue > 0)
                    objCombo.Tag = RetValue;
                clsDataBase.PopolaCombo(objCombo, Type);
            }
            return RetValue;
        }

    public static bool IsLetter(char KeyChar)
    {
      
      if ((KeyChar >= 'a' && KeyChar <= 'z') || (KeyChar >= 'A' && KeyChar <= 'Z'))
        return true;
      else
        return false;
    }

    public static bool IsNumber(char KeyChar)
        {
            if ((KeyChar < '0' || KeyChar > '9') && (int)KeyChar != 8)
                return false;
            else
                return true;
        }

        public static bool IsDecimal(char KeyChar)
        {
            if ((KeyChar < '0' || KeyChar > '9') && (int)KeyChar != 8 && KeyChar != '.')
                return false;
            else
                return true;
        }

        public static bool IsDecimal(string strValue)
        {
            bool bRet = true;
            int CountS=0;

            foreach (char chItem in strValue)
            {
                if (bRet)
                {
                    bRet = IsDecimal(chItem);
                    if (chItem == ',') CountS++;
                }   
            }


            if (CountS > 1)
                bRet = false;

            return bRet;
        }
        

        public static bool DataGridRowMoveUpDown(DataGridView objDataGrid, int idRow, bool MoveUp)
        {
            bool bRet = false;
            object objValue = null;
            int newPos = -1;

            if (objDataGrid.Rows.Count<2 || (MoveUp && idRow == 0) || (!MoveUp && idRow == objDataGrid.Rows.Count-1)) return bRet;
            if (MoveUp)
                newPos = idRow - 1;
            else
                newPos = idRow + 1;

            for (int i = 0; i < objDataGrid.Columns.Count; i++)
            { 
                objValue = objDataGrid[i,idRow].Value;
                objDataGrid[i, idRow].Value = objDataGrid[i, newPos].Value;
                objDataGrid[i, newPos].Value = objValue;
            }
            objDataGrid.CurrentCell = objDataGrid[objDataGrid.CurrentCell.ColumnIndex, newPos];
            return bRet;
        }
    }
}
