using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeIdentidades.Services
{
    public class IdentityGenService : IIdentityGenService
    {
        private readonly Random _random;

        private static string[] FirstNames = {
            "Maria",
            "João",
            "Ana",
            "Tiago",
            "Beatriz",
            "Diogo",
            "Matilde",
            "Martim",
            "Leonor",
            "Rodrigo",
        };

        private static string[] LastNames = {
            "Silva",
            "Santos",
            "Ferreira",
            "Pereira",
            "Oliveira",
            "Costa",
            "Rodrigues",
            "Martins",
            "Jesus",
            "Sousa",
        };

        public IdentityGenService()
        {
            _random = new Random();
        }

        private ulong GenDigitCtrlNumber(ulong prefix)
        {
            ulong len = 7;
            ushort i = 0;
            ulong num = prefix;
            uint sum = (uint)(num * 9);
            while (i++ < len)
            {
                uint randNo = (uint)(_random.Next() % 10);
                num = (num * 10) + randNo;
                sum += (uint)(randNo * (8 - (i - 1)));
            }
            uint ctrlDigit = sum % 11;
            if (ctrlDigit == 0 || ctrlDigit == 1)
                num = num * 10;
            else
                num = (num * 10) + (11 - ctrlDigit);
            return num;
        }

        private int GetNumberFromChar(char letter)
        {
            switch (letter)
            {
                case '0': return 0;
                case '1': return 1;
                case '2': return 2;
                case '3': return 3;
                case '4': return 4;
                case '5': return 5;
                case '6': return 6;
                case '7': return 7;
                case '8': return 8;
                case '9': return 9;
                case 'A': return 10;
                case 'B': return 11;
                case 'C': return 12;
                case 'D': return 13;
                case 'E': return 14;
                case 'F': return 15;
                case 'G': return 16;
                case 'H': return 17;
                case 'I': return 18;
                case 'J': return 19;
                case 'K': return 20;
                case 'L': return 21;
                case 'M': return 22;
                case 'N': return 23;
                case 'O': return 24;
                case 'P': return 25;
                case 'Q': return 26;
                case 'R': return 27;
                case 'S': return 28;
                case 'T': return 29;
                case 'U': return 30;
                case 'V': return 31;
                case 'W': return 32;
                case 'X': return 33;
                case 'Y': return 34;
                case 'Z': return 35;
            }
            return -1;
        }

        private char GetCharFromNumber(int number)
        {
            switch (number)
            {
                case 0: return '0';
                case 1: return '1';
                case 2: return '2';
                case 3: return '3';
                case 4: return '4';
                case 5: return '5';
                case 6: return '6';
                case 7: return '7';
                case 8: return '8';
                case 9: return '9';
                case 10: return 'A';
                case 11: return 'B';
                case 12: return 'C';
                case 13: return 'D';
                case 14: return 'E';
                case 15: return 'F';
                case 16: return 'G';
                case 17: return 'H';
                case 18: return 'I';
                case 19: return 'J';
                case 20: return 'K';
                case 21: return 'L';
                case 22: return 'M';
                case 23: return 'N';
                case 24: return 'O';
                case 25: return 'P';
                case 26: return 'Q';
                case 27: return 'R';
                case 28: return 'S';
                case 29: return 'T';
                case 30: return 'U';
                case 31: return 'V';
                case 32: return 'W';
                case 33: return 'X';
                case 34: return 'Y';
                case 35: return 'Z';
            }
            return '?';
        }

        public string GenCC()
        {
            ulong ccNum = GenDigitCtrlNumber(1);
            var cc = new char[14];
            var idx = 0;
            foreach (char c in ccNum.ToString())
            {
                cc[idx++] = c;
            }
            cc[9] = ' ';
            cc[10] = 'Z';
            cc[11] = 'Z';
            cc[12] = ' ';

            var noSpaceCC = new string(cc.Where(x => x != ' ').ToArray());

            int ctr = -1;
            long sum = 0;
            while (ctr++ < 10)
            {
                if (ctr % 2 == 0)
                {
                    uint pivot = (uint)(GetNumberFromChar(noSpaceCC[ctr]) * 2);
                    if (pivot >= 10)
                        pivot -= 9;
                    sum += pivot;
                    continue;
                }
                sum += GetNumberFromChar(noSpaceCC[ctr]);
            }
            uint ctrlDigit = 0;
            long tempSum = sum;
            while (tempSum % 10 != 0)
            {
                tempSum = sum;
                ctrlDigit++;
                tempSum += ctrlDigit;
            }
            cc[13] = GetCharFromNumber((int)ctrlDigit);

            return new string(cc);
        }

        public string GenName()
        {
            var firstNameIdx = _random.Next(FirstNames.Length);
            var lastNameIdx = _random.Next(LastNames.Length);
            return $"{FirstNames[firstNameIdx]} {LastNames[lastNameIdx]}";
        }

        public string GenNif()
        {
            ulong nif = GenDigitCtrlNumber(2);
            return nif.ToString();
        }
    }
}

