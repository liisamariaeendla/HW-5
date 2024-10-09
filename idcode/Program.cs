using Microsoft.VisualBasic;
using System.Globalization;

namespace idcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadFromFile("idCodes.txt");
        }

         public static void PrintIdCodeInfo(string idCode)
         {

            string sex = GetSex(idCode);
            string birthDate = GetBirthDate(idCode);
            string BirthPlace = GetBirthPlace(idCode);
            string lastNumber = CheckNumber(idCode);
            string birthNumber = GetBirthPlace(idCode);


            Console.WriteLine("Decoding id code " + idCode);
            Console.WriteLine("Sex: " + sex);
            Console.WriteLine("Birthdate: " + birthDate);
            Console.WriteLine("Birthplace or Birthnumber: " + BirthPlace);
            Console.WriteLine("CheckNr: " + lastNumber);

            

         }

       
        public bool ValidateCode(string idCode)
        {
            if (idCode.Length != 11)
            {
                Console.WriteLine("Id code must have 11 numbers");
                return false;
            }
            return true;



        }

        public static string GetSex(string idCode)
        {
            string sex;

            int firstNumber = int.Parse(idCode.Substring(0, 1));
            if (firstNumber == 1 || firstNumber == 3 || firstNumber == 5 )
            {
                sex = "male";
            }
            else if (firstNumber == 2 || firstNumber == 4 ||firstNumber == 6)
            {
                sex = "female";
            }
            else
            {
                return "Invalid first number";
            }


            return sex;
        }
        
        public static string GetBirthDate(string idCode)
        {
            
            string year = idCode.Substring(1, 2);
            string month = idCode.Substring(3, 2);
            string day = idCode.Substring(5, 2);

            return $"{day}.{month}.{year}";


        }
        public static bool IsValidDate(string dateText)
        {
            string format = "dd.MM.yyyy";
            try
            {
                DateTime.ParseExact(dateText, format, CultureInfo.CurrentCulture);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetBirthPlace(string idCode)
        {

            
            int birthNumber = int.Parse(idCode.Substring(7, 3));
            string birthPlace = " ";

            if (birthNumber < 13)
            {


                if (birthNumber >= 0 && birthNumber <= 10)
                {
                    birthPlace = "Kuressaare haigla";
                }
                else if (birthNumber >= 11 && birthNumber <= 19)
                {
                    birthPlace = "Tartu Ülikooli Naistekliinik";
                }
                else if (birthNumber >= 20 && birthNumber <= 150)
                {
                    birthPlace = "Ida-Tallinna keskhaigla, Pelgulinna sünnitusmaja (Tallinn)";
                }
                else if (birthNumber >= 151 && birthNumber <= 160)
                {
                    birthPlace = "Keila haigla";
                }
                else if (birthNumber >= 161 && birthNumber <= 219)
                {
                    birthPlace = "Rapla haigla, Loksa haigla, Hiiumaa haigla (Kärdla)";
                }
                else if (birthNumber >= 220 && birthNumber <= 270)
                {
                    birthPlace = "Ida-Viru keskhaigla (Kohtla-Järve, endine Jõhvi)";
                }
                else if (birthNumber >= 271 && birthNumber <= 370)
                {
                    birthPlace = "Maarjamõisa kliinikum (Tartu), Jõgeva haigla";
                }
                else if (birthNumber >= 371 && birthNumber <= 420)
                {
                    birthPlace = "Narva haigla";
                }
                else if (birthNumber >= 421 && birthNumber <= 470)
                {
                    birthPlace = "Pärnu haigla";
                }
                else if (birthNumber >= 471 && birthNumber <= 490)
                {
                    birthPlace = "Haapsalu haigla";
                }
                else if (birthNumber >= 491 && birthNumber <= 520)
                {
                    birthPlace = "Järvamaa haigla (Paide)";
                }
                else if (birthNumber >= 521 && birthNumber <= 570)
                {
                    birthPlace = "Rakvere haigla, Tapa haigla";
                }
                
                
            }
            else
            {
                birthPlace = $"{birthNumber}";
            }

            return birthPlace;
        }

       public static string CheckNumber(string idCode)
        {
            string lastNumber = idCode.Substring(10, 1);
            return lastNumber;
        }

        public static void ReadFromFile(string fileName)
        {
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine($"Reading line: {line}");
                        PrintIdCodeInfo(line);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
