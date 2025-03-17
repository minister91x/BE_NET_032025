using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE_032025.Common
{
    public static class ValidateDataInput
    {
        public static bool CheckValidInputNumber(string inputNumber)
        {
            if (string.IsNullOrEmpty(inputNumber))
            {
                return false;
            }

            inputNumber = inputNumber.Trim();

            if (!int.TryParse(inputNumber, out int num))
            {
                return false;
            }

            int numberInput = int.Parse(inputNumber); // Nhập số nguyên từ bàn phím

            if (numberInput > int.MaxValue)
            {
                return false;
            }

            return true;


        }

        public static bool CheckValidateString(string inputString)
        {
            if (string.IsNullOrEmpty(inputString))
            {
                return false;
            }

            if (int.TryParse(inputString, out int num))
            {
                return false;
            }

            if (inputString.Length > 200)
            {
                return false;
            }

            return true;
        }


        public static bool CheckSpecicalCharacter(string inputString)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(inputString)) { return false; }
            return true;
        }

        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<embed", "<frame", "<script", "<frameset", "<html", "<iframe", "<img", "<style", "<layer", "<link", "<ilayer", "<meta", "<object", "<h", "<input", "<a", "&lt", "&gt" };
                if (string.IsNullOrEmpty(input)) return false;
                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
