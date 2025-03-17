using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BE_032025.DataAccess.Struct;
using OfficeOpenXml;


namespace BE_032025.DataAccess
{
    public class Employeer_Manager
    {
        List<BE_032025.DataAccess.Struct.Employeer> empl = new List<Struct.Employeer>();
        public int Employeer_Insert(string EmployeerCodeInput, string EmployeerNameInput, DateTime StartDateInput)
        {
            var ketqua = 0;
            try
            {
                //Bước 1 : Kiểm tra dữ liệu đầu vào 

                if (!BE_032025.Common.ValidateDataInput.CheckValidateString(EmployeerCodeInput)
                    || !BE_032025.Common.ValidateDataInput.CheckXSSInput(EmployeerCodeInput))
                {
                    ketqua = (int)EmployeerManager_Status.MA_NHAN_VIEN_KHONG_HOP_LE;
                    return ketqua;
                }

                if (!BE_032025.Common.ValidateDataInput.CheckValidateString(EmployeerNameInput)
                     || !BE_032025.Common.ValidateDataInput.CheckXSSInput(EmployeerNameInput))
                {
                    ketqua = (int)EmployeerManager_Status.TEN_KHONG_HOP_LE;
                    return ketqua;
                }

                // Bước 2: Check trùng trong List chưa
                // c1 :
                var isDuplicate = false;
                for (int i = 0; empl.Count > 0; i++)
                {
                    // CTRL+K +D

                    if (empl[i].EmployeerCode == EmployeerCodeInput)
                    {
                        isDuplicate = true;
                        break;
                    }

                }

                if (isDuplicate)
                {
                    ketqua = (int)EmployeerManager_Status.DA_TON_TAI;
                    return ketqua;
                }

                //C2 : 
                //var isdup = empl.FindAll(s => s.EmployeerCode == EmployeerCodeInput).FirstOrDefault();

                //if (isdup.EmployeerCode != null)
                //{
                //    ketqua = (int)EmployeerManager_Status.DA_TON_TAI;
                //}


                //  Bước 3 : Thêm vào danh sách và nhận kết quả
                var new_emp = new Employeer();
                new_emp.EmployeerCode = EmployeerCodeInput;
                new_emp.EmployeerName = EmployeerNameInput;
                new_emp.StartDate = StartDateInput;


                empl.Add(new_emp);
                ketqua = (int)EmployeerManager_Status.THANH_CONG;
                return ketqua;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi ngoại lệ:" + ex.Message);
            }

            return ketqua;
        }

        public string Employeer_Insert_FromExcelFile(string filePath)
        {
            var ketqua = string.Empty;
            var errName = new StringBuilder();
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    for (int row = 2; row <= rowCount; row++)
                    {

                        var code = worksheet.Cells[row, 1].Text;
                        var name = worksheet.Cells[row, 2].Text;
                        var startDate = worksheet.Cells[row, 3].Text;

                        if (!BE_032025.Common.ValidateDataInput.CheckValidateString(code)
                    || !BE_032025.Common.ValidateDataInput.CheckXSSInput(code)
                    )
                        {
                            errName.Append("Hàng : " + row + "| Cột 0 dữ liệu không hợp lệ");
                            continue;
                        }
                        if (!BE_032025.Common.ValidateDataInput.CheckValidateString(name)
                 || !BE_032025.Common.ValidateDataInput.CheckXSSInput(name)
                 )
                        {
                            errName.Append("Hàng : " + row + "| Cột 1 dữ liệu không hợp lệ");
                            continue;
                        }
                    }

                    Console.WriteLine();
                }

                if (errName != null)
                {
                    return errName.ToString();
                }

            }
            catch (Exception ex)
            {

                throw;
            }

            return ketqua;
        }
    }
}
