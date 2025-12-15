using System.Text.RegularExpressions;

namespace NFSystem.Utils
{
    public static class CnpjValidator
    {
        public static bool IsValid(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj)) return false;

            var digits = Regex.Replace(cnpj, @"\D", "");
            if (digits.Length != 14) return false;

            string[] invalids = {
                "00000000000000","11111111111111","22222222222222","33333333333333",
                "44444444444444","55555555555555","66666666666666","77777777777777",
                "88888888888888","99999999999999"
            };
            if (invalids.Contains(digits)) return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string temp = digits.Substring(0, 12);
            int sum = 0;
            for (int i = 0; i < 12; i++) sum += int.Parse(temp[i].ToString()) * multiplicador1[i];
            int remainder = (sum % 11);
            int digito = remainder < 2 ? 0 : 11 - remainder;
            temp += digito;
            sum = 0;
            for (int i = 0; i < 13; i++) sum += int.Parse(temp[i].ToString()) * multiplicador2[i];
            remainder = (sum % 11);
            digito = remainder < 2 ? 0 : 11 - remainder;
            temp += digito;

            return temp.EndsWith(digits.Substring(12, 2));
        }
    }
}
